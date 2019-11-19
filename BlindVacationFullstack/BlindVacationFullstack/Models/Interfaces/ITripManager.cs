using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlindVacationFullstack.Models.Interfaces
{
    public interface ITripManager
    {
        /// <summary>
        /// Saves a trip as a SavedTrip to it's respective table.
        /// </summary>
        /// <param name="SavedTrip">Takes in the new SavedTrip to save.</param>
        Task SaveTrip(SavedTrip SavedTrip);
        /// <summary>
        /// Gets a SavedTrip based on the user ID and the answerCode.
        /// </summary>
        /// <param name="userid">Takes in the user ID</param>
        /// <param name="answerCode">Takes in the Answer Code string.</param>
        /// <returns>Returns the SavedTrip.</returns>
        Task<SavedTrip> GetTrip(int userid, string answerCode);
        /// <summary>
        /// Updates a SavedTrip.
        /// </summary>
        /// <param name="trip">Takes in the SavedTrip to be updated.</param>
        Task UpdateTrip(SavedTrip trip);
        /// <summary>
        /// Finds a trip based on user id and answer code string and removes it from the database.
        /// </summary>
        /// <param name="userid">Takes in the user's ID</param>
        /// <param name="answerCode">Takes in the answer code as a string.</param>
        Task DeleteTrip(int userid, string answerCode);
        /// <summary>
        /// Gets all PopularTrips from the popular trips table. Returns an IEnumerable of the PopularTrips.
        /// </summary>
        /// <returns>Returns an IEnumerable of PopularTrip.</returns>
        Task<IEnumerable<PopularTrip>> GetPopularTrips();
        /// <summary>
        /// Saves a trip as a PopularTrip to it's respective table.
        /// </summary>
        /// <param name="popularTrip">Takes in the new PopularTrip to save.</param>
        Task SaveAsPopularTrip(PopularTrip popularTrip);
    }


}
