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

        public async Task<IEnumerable<PopularTrip>> GetPopularTrips()
        {
            List<PopularTrip> PopTrips = await _context.PopularTrips.ToListAsync();
            return PopTrips;
        }

        public async Task<SavedTrip> GetTrip(int userid, string answerCode)
        {
            return await _context.SavedTrips.FirstOrDefaultAsync(x => x.AnswerCode == answerCode && x.UserID == userid);
        }

        public async Task SaveAsPopularTrip(PopularTrip trip)
        {
            var popularTrips = await _context.PopularTrips.ToListAsync();
            bool found = false;
            foreach(var popTrip in popularTrips)
            {
                if(popTrip.AnswerCode == trip.AnswerCode)
                {
                    popTrip.Popularity++;
                    _context.Update(popTrip);
                    await _context.SaveChangesAsync();
                    found = true;
                }
            }
            if (found == false)
            {
                await _context.AddAsync(trip);
                await _context.SaveChangesAsync();
            }
        }

        public async Task SaveTrip(SavedTrip savedTrip)
        {
            try
            {
            await _context.AddAsync(savedTrip);
            await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task UpdateTrip(SavedTrip trip)
        {
            _context.Update(trip);
            await _context.SaveChangesAsync();
        }
    }
}
