using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlindVacationFullstack.Models.Interfaces
{
    interface ITripManager
    {
        Task CreateTrip(Trip trip);
        Task<Trip> GetTrip(int userid, int recommendationCode);
        Task UpdateTrip(Trip trip);
        Task DeleteTrip(int userid, int recommendationCode);
    }
}
