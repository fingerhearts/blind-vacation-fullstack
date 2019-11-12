using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace BlindVacationFullstack.Data
{
    public class VacationMVCDbContext : DbContext
    {
        public VacationMVCDbContext(DbContextOptions<VacationMVCDbContext> options)
        {

        }
    }
}
