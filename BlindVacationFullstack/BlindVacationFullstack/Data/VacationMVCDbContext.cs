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

        /// <summary>
        /// seeding data into database
        /// </summary>
        /// <param name="modelBuilder"></param>
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
                    FaveTripItem = TripItem.Underwear
                },
                new User
                {
                    ID = 2,
                    Name = "Karina",
                    FaveTripItem = TripItem.Snacks
                },
                new User
                {
                    ID = 3,
                    Name = "Biniam",
                    FaveTripItem = TripItem.Passport
                },
                new User
                {
                    ID = 4,
                    Name = "Enrique",
                    FaveTripItem = TripItem.Games
                },
                new User
                {
                    ID = 5,
                    Name = "Chris",
                    FaveTripItem = TripItem.Charger
                });

            modelBuilder.Entity<SavedTrip>().HasData(
                new SavedTrip
                {
                    UserID = 1,
                    CityName = "Paris, France",
                    VacationName = "We need baguettes really badly.",
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
                    CityName = "Seoul, South Korea",
                    VacationName = "Korea Vacation 2020",
                    AnswerCode = "0,1,2,0,1",
                    Popularity = 3,
                    InUSA = false,
                    LikesHot = true,
                    Price = 2,
                    HasChildren = false,
                    LikesOutdoor = true
                },
                new PopularTrip
                {
                    ID = 2,
                    CityName = "Moscow, Russia",
                    VacationName = "Bring a coat!!",
                    AnswerCode = "0,0,2,0,0",
                    Popularity = 69,
                    InUSA = false,
                    LikesHot = false,
                    Price = 2,
                    HasChildren = false,
                    LikesOutdoor = false
                });


        }

        public DbSet<User> Users { get; set; }
        public DbSet<SavedTrip> SavedTrips { get; set; }
        public DbSet<PopularTrip> PopularTrips { get; set; }
    }
}
