using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlindVacationFullstack.Models;
using Microsoft.EntityFrameworkCore;
using static BlindVacationFullstack.Models.User;

namespace BlindVacationFullstack.Data
{
    public class VacationMVCDbContext : DbContext
    {
        public VacationMVCDbContext(DbContextOptions<VacationMVCDbContext> options) : base(options) 
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Trip>().HasKey(trip =>
            new { trip.UserID, trip.RecommendationCode });


            //data seeding
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    ID = 1,
                    Name = "Kyungrae",
                    FaveColor = Color.White
                },
                new User
                {
                    ID = 2,
                    Name = "Karina",
                    FaveColor = Color.Ivory
                },
                new User
                {
                    ID = 3,
                    Name = "Biniam",
                    FaveColor = Color.Blue
                },
                new User
                {
                    ID = 4,
                    Name = "Enrique",
                    FaveColor = Color.Cyan
                },
                new User
                {
                    ID = 5,
                    Name = "Chris",
                    FaveColor = Color.Pink
                });
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Trip> Trips { get; set; }

    }
}
