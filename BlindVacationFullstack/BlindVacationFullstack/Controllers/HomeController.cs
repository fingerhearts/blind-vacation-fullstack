using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Http;

namespace BlindVacationFullstack.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
        /// Returns the default index (Homepage) of the website.
        /// </summary>
        /// <returns>Returns the default index (Homepage) of the website.</returns>
        public IActionResult Index()
        {
            return View();
        }
    }
}
