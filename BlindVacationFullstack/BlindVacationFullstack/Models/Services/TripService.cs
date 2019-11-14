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
        /// <summary>
        /// feeding _context the database contents
        /// </summary>
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
        /// <summary>
        /// allows a user to delete one of their saved trips by using it's answerCode
        /// </summary>
        /// <param name="userid"></param>
        /// <param name="answerCode"></param>
        /// <returns></returns>
        public async Task DeleteTrip(int userid, string answerCode)
        {
            _context.Remove(await (GetTrip(userid, answerCode)));
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Popular trips are saved based on user usage. this creates a lst that is then returned
        /// </summary>
        /// <returns>PopTrips, a variable containing a list of popular trips</returns>
        public async Task<IEnumerable<PopularTrip>> GetPopularTrips()
        {
            List<PopularTrip> PopTrips = await _context.PopularTrips.ToListAsync();
            return PopTrips;
        }

        /// <summary>
        /// Pulls up a trip from the saved trip list to
        /// </summary>
        /// <param name="userid"></param>
        /// <param name="answerCode"></param>
        /// <returns>selected trip</returns>
        public async Task<SavedTrip> GetTrip(int userid, string answerCode)
        {
            return await _context.SavedTrips.FirstOrDefaultAsync(x => x.AnswerCode == answerCode && x.UserID == userid);
        }

        /// <summary>
        /// Saved the newly recommended trip, and the
        /// </summary>
        /// <param name="trip"></param>
        /// <returns></returns>
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
