using BlindVacationFullstack.Data;
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

        public async Task CreateUser(User user)
        {
            await _context.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteUser(int userid)
        {
            _context.Remove(await GetUser(userid));
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Trip>> GetSavedTrips(int userid)
        {
            var trips = await _context.Trips.Where(x => x.UserID == userid).ToListAsync();
            return trips;
        }

        public async Task<User> GetUser(int userid)
        {
            return await _context.Users.FirstOrDefaultAsync(x => x.ID == userid);
        }

        public async Task UpdateUser(User user)
        {
            _context.Update(user);
            await _context.SaveChangesAsync();
        }
    }
}
