using BlindVacationFullstack.Models.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;
using static BlindVacationFullstack.Models.User;

namespace BlindVacationFullstack.Models.Interfaces
{
    /// <summary>
    /// creates a user, and once created, adds saved trips into this users profile.
    /// adds the capability of login in
    /// </summary>
    public interface IUserManager
    {
        /// <summary>
        /// Takes in a user and adds the user to the database.
        /// </summary>
        /// <param name="user">Takes in a user to be save in the database.</param>
        Task CreateUser(User user);
        /// <summary>
        /// Returns a user object of the corresponding user from the database.
        /// </summary>
        /// <param name="userid">Takes in a user ID as an integer.</param>
        /// <returns>Returns User object.</returns>
        Task<User> GetUser(int userid);
        /// <summary>
        /// Takes in a user and updates the database with new user details.
        /// </summary>
        /// <param name="user">Takes in a User object.</param>
        /// <returns></returns>
        Task UpdateUser(User user);
        /// <summary>
        /// Takes in a user ID, queries the database for the ID and removes that ID from the database.
        /// </summary>
        /// <param name="userid">Takes in the user ID as an integer.</param>
        Task DeleteUser(int userid);
        /// <summary>
        /// Takes in a user ID and returns all trips associated with the user from the trips
        /// database.
        /// </summary>
        /// <param name="userid">Takes in a user ID as an integer.</param>
        /// <returns>Returns the list of Trips as a List Collection</returns>
        Task<IEnumerable<SavedTrip>> GetSavedTrips(int userid);
        /// <summary>
        /// Takes in the user name and checks the Trip Item to "Log the user in".
        /// </summary>
        /// <param name="Name">Takes in the user's name</param>
        /// <param name="tripItem">Takes in the trip item ENUM</param>
        /// <returns>Returns the User's ID.</returns>
        Task<int> Login(string Name, TripItem tripItem);

    }
}