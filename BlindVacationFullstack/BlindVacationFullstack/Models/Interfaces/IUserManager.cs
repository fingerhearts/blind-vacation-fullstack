using BlindVacationFullstack.Models.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;
using static BlindVacationFullstack.Models.User;

namespace BlindVacationFullstack.Models.Interfaces
{
    public interface IUserManager
    {
        Task CreateUser(User user);
        Task<User> GetUser(int userid);
        Task UpdateUser(User user);
        Task DeleteUser(int userid);
        Task<IEnumerable<SavedTrip>> GetSavedTrips(int userid);
        Task<int> Login(string Name, Color color);

    }
}