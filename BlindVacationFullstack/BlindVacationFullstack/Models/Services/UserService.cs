﻿using BlindVacationFullstack.Data;
using BlindVacationFullstack.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlindVacationFullstack.Models.Services
{
    public class UserService : IUserManager
    {
        private VacationMVCDbContext _context;
        public UserService(VacationMVCDbContext context)
        {
            _context = context;
        }
        /// <summary>
        /// Takes in a user and adds the user to the database.
        /// </summary>
        /// <param name="user">Takes in a user to be save in the database.</param>
        public async Task CreateUser(User user)
        {
            await _context.AddAsync(user);
            await _context.SaveChangesAsync();
        }
        /// <summary>
        /// Takes in a user ID, queries the database for the ID and removes that ID from the database.
        /// </summary>
        /// <param name="userid">Takes in the user ID as an integer.</param>
        public async Task DeleteUser(int userid)
        {
            _context.Remove(await GetUser(userid));
            await _context.SaveChangesAsync();
        }
        /// <summary>
        /// Takes in a user ID and returns all trips associated with the user from the trips
        /// database.
        /// </summary>
        /// <param name="userid">Takes in a user ID as an integer.</param>
        /// <returns>Returns the list of Trips as a List Collection</returns>
        public async Task<IEnumerable<SavedTrip>> GetSavedTrips(int userid)
        {
            var trips = await _context.SavedTrips.Where(x => x.UserID == userid).ToListAsync();
            return trips;
        }
        /// <summary>
        /// Returns a user object of the corresponding user from the database.
        /// </summary>
        /// <param name="userid">Takes in a user ID as an integer.</param>
        /// <returns>Returns User object.</returns>
        public async Task<User> GetUser(int userid)
        {
            return await _context.Users.FirstOrDefaultAsync(x => x.ID == userid);
        }
        /// <summary>
        /// Takes in the user name and checks the Trip Item to "Log the user in".
        /// </summary>
        /// <param name="Name">Takes in the user's name</param>
        /// <param name="tripItem">Takes in the trip item ENUM</param>
        /// <returns>Returns the User's ID.</returns>
        public async Task<int> Login(string Name, User.TripItem tripItem)
        {
            User user = await _context.Users.FirstOrDefaultAsync(x => x.Name == Name && x.FaveTripItem == tripItem);
            if (user == null)
            {
                return 0;
            }
            else
            {
                return user.ID;
            }
        }
        /// <summary>
        /// Takes in a user and updates the database with new user details.
        /// </summary>
        /// <param name="user">Takes in a User object.</param>
        /// <returns></returns>
        public async Task UpdateUser(User user)
        {
            _context.Update(user);
            await _context.SaveChangesAsync();
        }
    }
}
