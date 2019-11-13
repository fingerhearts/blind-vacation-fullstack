using BlindVacationFullstack.Models;
using BlindVacationFullstack.Views.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlindVacationFullstack.Controllers
{
    public class SurveyController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(Survey survey)
        {
            EditTripViewModel etvm = new EditTripViewModel();
            etvm.AnswerCode = 
                $"usa={survey.InUSA}&" +
                $"hot={survey.LikesHot}&" +
                $"price={survey.Price}&" +
                $"children={survey.HasChildren}&" +
                $"outdoor={survey.LikesOutdoor}";
            return RedirectToAction("Edit", "Trip", etvm);
        }
    }
}
