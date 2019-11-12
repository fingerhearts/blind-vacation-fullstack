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
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet("test")]
        public async Task<IActionResult> TestAPI()
        {
            using(var client = new HttpClient())
            {
                try
                {
                    client.BaseAddress = new Uri("https://blindvacationapi.azurewebsites.net");
                    var response = await client.GetAsync("api/hello");
                    response.EnsureSuccessStatusCode();

                    var stringResult = await response.Content.ReadAsStringAsync();
                    return Ok(stringResult);
                }
                catch (Exception)
                {
                    return BadRequest($"Can't Connect to API :(");
                }
            }
        }
    }
}
