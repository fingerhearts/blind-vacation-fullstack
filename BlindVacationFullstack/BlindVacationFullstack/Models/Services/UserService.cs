using BlindVacationFullstack.Data;
using BlindVacationFullstack.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlindVacationFullstack.Models.Services
{
    public class UserService : IUserManager
    {
        private VacationMVCDbContext _context;
        public UserService(VacationMVCDbContext context)
        {
            _context = context;
        }
    }
}
