using BlindVacationFullstack.Data;
using BlindVacationFullstack.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlindVacationFullstack.Models.Services
{
    public class TripService : ITripManager
    {
        private VacationMVCDbContext _context;
        public TripService(VacationMVCDbContext context)
        {
            _context = context;
        }
        public async Task CreateTrip(SavedTrip trip)
        {
            await _context.AddAsync(trip);
            await _context.SaveChangesAsync();

        }

        public async Task DeleteTrip(int userid, string answerCode)
        {
            _context.Remove(await (GetTrip(userid, answerCode)));
            await _context.SaveChangesAsync();
        }

        public async Task<SavedTrip> GetTrip(int userid, string answerCode)
        {
            return await _context.SavedTrips.FirstOrDefaultAsync(x => x.AnswerCode == answerCode && x.UserID == userid);
        }

        public async Task UpdateTrip(SavedTrip trip)
        {
            _context.Update(trip);
            await _context.SaveChangesAsync();
        }
    }
}
