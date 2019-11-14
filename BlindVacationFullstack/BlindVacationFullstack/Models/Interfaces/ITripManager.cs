using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlindVacationFullstack.Models.Interfaces
{
    public interface ITripManager
    {
        Task CreateTrip(SavedTrip trip);
        Task<SavedTrip> GetTrip(int userid, string answerCode);
        Task UpdateTrip(SavedTrip trip);
        Task DeleteTrip(int userid, string answerCode);
        Task<IEnumerable<PopularTrip>> GetPopularTrips();
    }


}
