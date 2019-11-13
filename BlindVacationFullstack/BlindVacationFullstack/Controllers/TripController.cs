using BlindVacationFullstack.Models;
using BlindVacationFullstack.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public IActionResult Index(Survey survey)
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
            

            //dummydata
            string json = @"{
'id': 0,
'city': {
                'id': 1,
'name': 'Seattle, Washington',
'description': 'Seattle, a city on Puget Sound in the Pacific Northwest, is surrounded by water, mountains and evergreen forests, and contains thousands of acres of parkland. Washington State’s largest city, it’s home to a large tech industry, with Microsoft and Amazon headquartered in its metropolitan area. The futuristic Space Needle, a 1962 World’s Fair legacy, is its most iconic landmark.',
'imageURL': '',
'hot': false,
'inUSA': true,
'price': 2
},
'hotel': {
                'id': 1,
'cityID': 1,
'name': 'Roy Street Commons',
'price': 1,
'city': {
                    'id': 1,
'name': 'Seattle, Washington',
'description': 'Seattle, a city on Puget Sound in the Pacific Northwest, is surrounded by water, mountains and evergreen forests, and contains thousands of acres of parkland. Washington State’s largest city, it’s home to a large tech industry, with Microsoft and Amazon headquartered in its metropolitan area. The futuristic Space Needle, a 1962 World’s Fair legacy, is its most iconic landmark.',
'imageURL': '',
'hot': false,
'inUSA': true,
'price': 2
}
            },
'activity': {
                'id': 1,
'cityID': 1,
'name': '1) Visit the Space Needle:2) Ride the Duck \r\n:3) Tour Pike Place Market \r\n                ',
'familyFriendly': true,
'outdoors': true,
'city': {
                    'id': 1,
'name': 'Seattle, Washington',
'description': 'Seattle, a city on Puget Sound in the Pacific Northwest, is surrounded by water, mountains and evergreen forests, and contains thousands of acres of parkland. Washington State’s largest city, it’s home to a large tech industry, with Microsoft and Amazon headquartered in its metropolitan area. The futuristic Space Needle, a 1962 World’s Fair legacy, is its most iconic landmark.',
'imageURL': '',
'hot': false,
'inUSA': true,
'price': 2
}
            },
'recommendationCode': 0
}";

            EditTripViewModel deserializedProduct = JsonConvert.DeserializeObject<EditTripViewModel>(json);
            

            return View("Details", deserializedProduct);
        }
    }
}
