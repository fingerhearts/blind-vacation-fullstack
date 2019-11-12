using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlindVacationFullstack.Models.Interfaces
{
    public interface IUserManager
    {
        Task CreateUser(User user);
        Task<User> GetUser(int userid);
        Task UpdateUser(User user);
        Task DeleteUser(int userid);
        Task<IEnumerable<Trip>> GetSavedTrips(int userid);

    }
}