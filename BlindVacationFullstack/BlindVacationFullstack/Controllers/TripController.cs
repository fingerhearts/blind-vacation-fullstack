using BlindVacationFullstack.Models;
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
        public IActionResult Index()
        {
            return View();
        }

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


                    return View("Details", responseItem);
                }
                catch (Exception)
                {
                    return BadRequest($"Can't Connect to API :(");
                }
            }
        }           
    }
}
