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
            modelBuilder.Entity<SavedTrip>().HasKey(trip =>
            new { trip.UserID, trip.AnswerCode });


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

            modelBuilder.Entity<SavedTrip>().HasData(
                new SavedTrip
                {
                    UserID = 1,
                    CityName = "Tunisia",
                    VacationName = "Chris bachelor party",
                    AnswerCode = "0,1,1,0,1",
                    InUSA = false,
                    LikesHot = true,
                    Price = 1,
                    HasChildren = false,
                    LikesOutdoor = true
                },
                new SavedTrip
                {
                    UserID = 1,
                    CityName = "Paris",
                    VacationName = "Chris divorce party",
                    AnswerCode = "0,1,3,0,0",
                    InUSA = false,
                    LikesHot = true,
                    Price = 3,
                    HasChildren = false,
                    LikesOutdoor = false
                }); 
            modelBuilder.Entity<PopularTrip>().HasData(
                new PopularTrip
                {
                    ID = 1,
                    CityName = "North Korea",
                    VacationName = "Chris baptism party",
                    AnswerCode = "0,1,1,0,1",
                    Popularity = 3,
                    InUSA = false,
                    LikesHot = true,
                    Price = 1,
                    HasChildren = false,
                    LikesOutdoor = true
                },
                new PopularTrip
                {
                    ID = 2,
                    CityName = "Paris",
                    VacationName = "Chris Refugee party",
                    AnswerCode = "0,1,3,0,0",
                    Popularity = 69,
                    InUSA = false,
                    LikesHot = true,
                    Price = 3,
                    HasChildren = false,
                    LikesOutdoor = false
                });


        }

        public DbSet<User> Users { get; set; }
        public DbSet<SavedTrip> SavedTrips { get; set; }
        public DbSet<PopularTrip> PopularTrips { get; set; }
    }
}
