using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlindVacationFullstack.Models.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BlindVacationFullstack.Models;
using static BlindVacationFullstack.Models.User;

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

        [HttpPost]
        public async Task<IActionResult> Index(string Name, Color FaveColor)
        {
            int userID = await _context.Login(Name, FaveColor);
            if (userID <= 0)
            {
                return NotFound();
            }
            return Redirect($"user/details/{userID}");
        }

        //C
        public IActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// creates a user and adds it to the database
        /// </summary>
        /// <param name="user">takes in a user</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,FaveColor")] User user)
        {
            if(ModelState.IsValid)
            {
                await _context.CreateUser(user);
                //TODO: Redirect to details or MyTrips page
                return Redirect($"~/user/details/{user.ID}");
            }
            return View(user);
        }

        //R
        public async Task<IActionResult> Details(int id)
        {
            if(id <= 0)
            {
                return NotFound();
            }
            //TODO send user to details id
            var user = await _context.GetUser(id);
            if(user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        //U
        public async Task<IActionResult> Edit(int id)
        {
            if(id <= 0)
            {
                return NotFound();
            }

            var user = await _context.GetUser(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,FaveColor")] User user)
        {
            if(id != user.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _context.UpdateUser(user);
                //TODO Redirect to Details/userid
                return RedirectToAction(nameof(Index));
            }
            return View(user);


        }

        //D
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0)
            {
                return NotFound();
            }

            var user = await _context.GetUser(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }
        /// <summary>
        /// Http Post call removes the user from database based on ID
        /// </summary>
        /// <param name="id">takes in a userId as an integer</param>
        /// <returns></returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]

        
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _context.DeleteUser(id);
            return RedirectToAction(nameof(Index));
        }

    }
}
