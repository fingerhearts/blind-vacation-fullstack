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
        public async Task CreateTrip(Trip trip)
        {
            await _context.AddAsync(trip);
            await _context.SaveChangesAsync();

        }

        public async Task DeleteTrip(int userid, int recommendationCode)
        {
            _context.Remove(await (GetTrip(userid, recommendationCode)));
            await _context.SaveChangesAsync();
        }

        public async Task<Trip> GetTrip(int userid, int recommendationCode)
        {
            return await _context.Trips.FirstOrDefaultAsync(x => x.RecommendationCode == recommendationCode && x.UserID == userid);
        }

        public async Task UpdateTrip(Trip trip)
        {
            _context.Update(trip);
            await _context.SaveChangesAsync();
        }
    }
}
