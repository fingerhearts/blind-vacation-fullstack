using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlindVacationFullstack.Models.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BlindVacationFullstack.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserManager _context;

        public UserController(IUserManager context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        //C

        //R

        //U

        //D
    }
}
