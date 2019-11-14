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
        Task CreateUser(User user);
        Task<User> GetUser(int userid);
        Task UpdateUser(User user);
        Task DeleteUser(int userid);
        Task<IEnumerable<SavedTrip>> GetSavedTrips(int userid);
        Task<int> Login(string Name, TripItem tripItem);

    }
}