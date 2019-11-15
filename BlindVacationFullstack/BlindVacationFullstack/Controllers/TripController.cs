using BlindVacationFullstack.Models;
using BlindVacationFullstack.Models.Interfaces;
using BlindVacationFullstack.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace BlindVacationFullstack.Controllers
{
    public class TripController : Controller
    {
        /// <summary>
        /// Access to the SavedTrips database through the ITripManager interface.
        /// </summary>
        private readonly ITripManager _trips;
        /// <summary>
        /// Access to the Users database table through the IUserManager interface.
        /// </summary>
        private readonly IUserManager _users;
        /// <summary>
        /// Constructor for TripController. Takes in two interface parameters and defines them to the two corresponding properties.
        /// </summary>
        /// <param name="trips">Takes in a ITripManager variable.</param>
        /// <param name="users">Takes in a IUserManager variable.</param>
        public TripController(ITripManager trips, IUserManager users)
        {
            _trips = trips;
            _users = users;
        }
        /// <summary>
        /// Default HTTP get function for /Trip. Returns the index view which is a view with a survey.
        /// </summary>
        /// <returns>Returns Index.cshtml</returns>
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Takes in a survey and parses the answers into an answer string. 
        /// String is sent to API and the object returned is parsed into a view model.
        /// That model is returned to the view Details action
        /// </summary>
        /// <param name="survey">Survey object</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Index(Survey survey)
        {
            EditTripViewModel etvm = new EditTripViewModel();
            etvm.AnswerCode = "";
            etvm.AnswerCode += survey.InUSA ? "1," : "0,";
            etvm.AnswerCode += survey.LikesHot ? "1," : "0,";
            switch (survey.Price)
            {
                case 1:
                    etvm.AnswerCode += "1,";
                    break;
                case 2:
                    etvm.AnswerCode += "2,";
                    break;
                case 3:
                    etvm.AnswerCode += "3,";
                    break;
            }
            etvm.AnswerCode += survey.HasChildren ? "1," : "0,";
            etvm.AnswerCode += survey.LikesOutdoor ? "1" : "0";

            using (var client = new HttpClient())
            {
                try
                {
                    client.BaseAddress = new Uri("https://blindvacationapi.azurewebsites.net");
                    var response = await client.GetAsync($"api/plan/{etvm.AnswerCode}");
                    response.EnsureSuccessStatusCode();

                    var stringResult = await response.Content.ReadAsStringAsync();
                    EditTripViewModel responseItem = JsonConvert.DeserializeObject<EditTripViewModel>(stringResult);

                    responseItem.Activities = responseItem.Activity.Name.Split("\r\n");

                    //TODO: remove hardcoded data
                    responseItem.User = await _users.GetUser(1);

                    responseItem.AnswerCode = etvm.AnswerCode;
                    return View("Details", responseItem);
                }
                catch (Exception)
                {
                    return BadRequest($"Can't Connect to API :(");
                }
            }
        }
        /// <summary>
        /// This action takes in parameters of the survey and creates a SavedTrip and a PopularTrip. It parses through
        /// the answer string and creates properties based on the string characters. It saves the
        /// popular trip to the database, then tries to save the SavedTrip to the database. If an error is thrown,
        /// an error screen is shown.
        /// </summary>
        /// <param name="AnswerCode"> AnswerCode from the survey as a string.</param>
        /// <param name="CityName">Takes in the city name as a string.</param>
        /// <param name="VacationName">Takes in the user inputted name of the vacation as a string.</param>
        /// <param name="UserID">Takes in the user ID of the user performing the action.</param>
        /// <returns>Returns the view of MyVacations based on the user ID.</returns>
        [HttpPost]
        public async Task<IActionResult> Details(string AnswerCode, string CityName, string VacationName, int UserID)
        {
            SavedTrip trip = new SavedTrip
            {
                AnswerCode = AnswerCode,
                CityName = CityName,
                VacationName = VacationName,
                UserID = UserID,
                InUSA = (AnswerCode[0] == '1' ? true : false),
                LikesHot = (AnswerCode[2] == '1' ? true : false),

                HasChildren = (AnswerCode[6] == '1' ? true : false),
                LikesOutdoor = (AnswerCode[8] == '1' ? true : false)
            };
      
            PopularTrip popTrip = new PopularTrip
            {
                AnswerCode = AnswerCode,
                CityName = CityName,
                VacationName = VacationName,
                Popularity = 0,
                InUSA = (AnswerCode[0] == '1' ? true : false),
                LikesHot = (AnswerCode[2] == '1' ? true : false),

                HasChildren = (AnswerCode[6] == '1' ? true : false),
                LikesOutdoor = (AnswerCode[8] == '1' ? true : false)
            };
            switch (AnswerCode[4])
            {
                case '1':
                    trip.Price = 1;
                    popTrip.Price = 1;
                    break;
                case '2':
                    trip.Price = 2;
                    popTrip.Price = 2;
                    break;
                case '3':
                    trip.Price = 3;
                    popTrip.Price = 3;
                    break;
            }

            await _trips.SaveAsPopularTrip(popTrip);
            try
            {
                await _trips.SaveTrip(trip);
            }
            catch (Exception)
            {
                return Ok("You already saved a vacation just like that! Try again.");
            }
            return RedirectToAction("MyVacations", UserID);
        }
        
        public async Task<IActionResult> MyVacations(int userID)
        {
            userID = 1;
            var myTrips = await _users.GetSavedTrips(userID);
            return View(myTrips);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteSavedTrip(int userID, string answerCode)
        {
            await _trips.DeleteTrip(userID, answerCode);
            return RedirectToAction("MyVacations");
        }

        [HttpPost]
        public async Task<IActionResult> MyVacations(bool InUSA, bool LikesHot, int Price, bool HasChildren, bool LikesOutdoor)
        {
            Survey survey = new Survey()
            {
                InUSA = InUSA,
                LikesHot = LikesHot,
                Price = Price,
                HasChildren = HasChildren,
                LikesOutdoor = LikesOutdoor
            };
            EditTripViewModel etvm = new EditTripViewModel();
            etvm.AnswerCode = "";
            etvm.AnswerCode += survey.InUSA ? "1," : "0,";
            etvm.AnswerCode += survey.LikesHot ? "1," : "0,";
            switch (survey.Price)
            {
                case 1:
                    etvm.AnswerCode += "1,";
                    break;
                case 2:
                    etvm.AnswerCode += "2,";
                    break;
                case 3:
                    etvm.AnswerCode += "3,";
                    break;
            }
            etvm.AnswerCode += survey.HasChildren ? "1," : "0,";
            etvm.AnswerCode += survey.LikesOutdoor ? "1" : "0";

            using (var client = new HttpClient())
            {
                try
                {
                    client.BaseAddress = new Uri("https://blindvacationapi.azurewebsites.net");
                    var response = await client.GetAsync($"api/plan/{etvm.AnswerCode}");
                    response.EnsureSuccessStatusCode();

                    var stringResult = await response.Content.ReadAsStringAsync();
                    EditTripViewModel responseItem = JsonConvert.DeserializeObject<EditTripViewModel>(stringResult);
                    responseItem.Activities = responseItem.Activity.Name.Split("\r\n");

                    //TODO: remove hardcoded data
                    responseItem.User = await _users.GetUser(1);

                    responseItem.AnswerCode = etvm.AnswerCode;
                    return View("Details", responseItem);
                }
                catch (Exception)
                {
                    return BadRequest($"Can't Connect to API :(");
                }
            }
        }

        public async Task<IActionResult> Popular()
        {
            var popular = await _trips.GetPopularTrips();
            PopularTrip[] popArr = popular.ToArray();
            bool sorted = false;
            while (sorted == false)
            {
                int count = 0;
                for (int i = 0; i < popArr.Length; i++)
                {
                    if (i < popArr.Length - 1)
                    {
                        if (popArr[i].Popularity > popArr[i + 1].Popularity)
                        {
                            PopularTrip sort = popArr[i];
                            popArr[i] = popArr[i + 1];
                            popArr[i + 1] = sort;
                            count++;
                        }
                    }
                }
                if (count == 0)
                {
                    sorted = true;
                }
            }
            return View(popArr);
        }

    }
}
