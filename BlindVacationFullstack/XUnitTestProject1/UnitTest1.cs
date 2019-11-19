using BlindVacationFullstack.Controllers;
using BlindVacationFullstack.Data;
using BlindVacationFullstack.Models;
using BlindVacationFullstack.Models.Interfaces;
using BlindVacationFullstack.Models.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using Xunit;

namespace XUnitTestProject1
{
    public class UnitTest1
    {
        #region Getter Setter Tests
        [Fact]
        public void GetterSetterTestUser()
        {
            User user = new User();
            user.ID = 1;
            user.Name = "Hoopty";
            user.FaveTripItem = User.TripItem.Hat;

            Assert.Equal(1, user.ID);
            Assert.Equal("Hoopty", user.Name);
            Assert.Equal(User.TripItem.Hat, user.FaveTripItem);
        }
        [Fact]
        public void GetterSetterTestActivity()
        {
            Activity activity = new Activity()
            {
                Name = "Hamburger",
                IsOutdoor = true,
                FamilyFriendly = false
            };

            Assert.Equal("Hamburger", activity.Name);
            Assert.True(activity.IsOutdoor);
            Assert.False(activity.FamilyFriendly);
        }
        [Fact]
        public void GetterSetterTestCity()
        {
            City city = new City()
            {
                Name = "Honolulu",
                Description = "Hot",
                ImageUrl = "something",
                InUSA = true,
                IsHot = true,
                Price = 3
            };
            Assert.Equal("Honolulu", city.Name);
            Assert.Equal("Hot", city.Description);
            Assert.Equal("something", city.ImageUrl);
            Assert.True(city.InUSA);
            Assert.True(city.IsHot);
            Assert.Equal(3, city.Price);
        }
        [Fact]
        public void GetterSetterTestHotel()
        {
            Hotel hotel = new Hotel()
            {
                Name = "Meow",
                ImageUrl = "help",
                Price = 3
            };
            Assert.Equal("Meow", hotel.Name);
            Assert.Equal("help", hotel.ImageUrl);
            Assert.Equal(3, hotel.Price);
        }
        [Fact]
        public void GetterSetterTestPopularTrip()
        {
            PopularTrip popularTrip = new PopularTrip
            {
                ID = 100,
                CityName = "Crabs",
                VacationName = "lobsters",
                AnswerCode = "shwoop",
                Popularity = 13,
                InUSA = true,
                LikesHot = true,
                Price = 1,
                HasChildren = false,
                LikesOutdoor = true
            };
            Assert.Equal(100, popularTrip.ID);
            Assert.Equal("Crabs", popularTrip.CityName);
            Assert.Equal("lobsters", popularTrip.VacationName);
            Assert.Equal("shwoop", popularTrip.AnswerCode);
            Assert.Equal(13, popularTrip.Popularity);
            Assert.True(popularTrip.InUSA);
            Assert.True(popularTrip.LikesHot);
            Assert.Equal(1, popularTrip.Price);
            Assert.False(popularTrip.HasChildren);
            Assert.True(popularTrip.LikesOutdoor);
        }
        [Fact]
        public void GetterSetterTestSavedTrip()
        {
            SavedTrip savedtrip = new SavedTrip
            {
                UserID = 50,
                CityName = "Hubba",
                VacationName = "lubba",
                AnswerCode = "loop",
                InUSA = false,
                LikesHot = false,
                Price = 2,
                HasChildren = true,
                LikesOutdoor = true,
            };
            Assert.Equal(50, savedtrip.UserID);
            Assert.Equal("Hubba", savedtrip.CityName);
            Assert.Equal("lubba", savedtrip.VacationName);
            Assert.Equal("loop", savedtrip.AnswerCode);
            Assert.False(savedtrip.InUSA);
            Assert.False(savedtrip.LikesHot);
            Assert.Equal(2, savedtrip.Price);
            Assert.True(savedtrip.HasChildren);
            Assert.True(savedtrip.LikesOutdoor);
        }
        [Fact]
        public void GetterSetterTestSurvey()
        {
            Survey survey = new Survey()
            {
                InUSA = false,
                LikesHot = true,
                Price = 3,
                HasChildren = true,
                LikesOutdoor = false
            };
            Assert.False(survey.InUSA);
            Assert.True(survey.LikesHot);
            Assert.Equal(3, survey.Price);
            Assert.True(survey.HasChildren);
            Assert.False(survey.LikesOutdoor);
        }
        #endregion
        #region DB CRUD tests
        [Fact]
        public async Task SaveUserInDBAsync()
        {
            DbContextOptions<VacationMVCDbContext> options = new DbContextOptionsBuilder<VacationMVCDbContext>()
            .UseInMemoryDatabase("SaveUserInDBAsync")
            .Options;

            using (VacationMVCDbContext context = new VacationMVCDbContext(options))
            {
                UserService service = new UserService(context);
                User user = new User();
                user.ID = 3;
                user.Name = "Scoopty";
                user.FaveTripItem = User.TripItem.Sunscreen;

                await service.CreateUser(user);
                await context.SaveChangesAsync();

                User result = await context.Users.FirstOrDefaultAsync(x => x.ID == user.ID);

                Assert.Equal("Scoopty", result.Name);
            }
        }
        [Fact]
        public async Task UpdateUserInDBAsync()
        {
            DbContextOptions<VacationMVCDbContext> options = new DbContextOptionsBuilder<VacationMVCDbContext>()
                .UseInMemoryDatabase("UpdateUserInDBAsync")
                .Options;

            using (VacationMVCDbContext context = new VacationMVCDbContext(options))
            {
                UserService service = new UserService(context);
                User user = new User();
                user.ID = 4;
                user.Name = "Boopty";
                user.FaveTripItem = User.TripItem.Games;

                context.Add(user);
                await context.SaveChangesAsync();

                user.Name = "Woopty";
                await service.UpdateUser(user);
                await context.SaveChangesAsync();

                User result = await context.Users.FirstOrDefaultAsync(x => x.ID == user.ID);

                Assert.Equal("Woopty", result.Name);
            }
        }
        [Fact]
        public async Task DeleteUserFromDBAsync()
        {
            DbContextOptions<VacationMVCDbContext> options = new DbContextOptionsBuilder<VacationMVCDbContext>()
                .UseInMemoryDatabase("DeleteUserFromDBAsync")
                .Options;

            using (VacationMVCDbContext context = new VacationMVCDbContext(options))
            {
                UserService service = new UserService(context);
                User user = new User();
                user.ID = 5;
                user.Name = "Fwoopty";
                user.FaveTripItem = User.TripItem.FlipFlops;

                context.Add(user);
                await context.SaveChangesAsync();

                await service.DeleteUser(user.ID);
                await context.SaveChangesAsync();

                User result = await context.Users.FirstOrDefaultAsync(x => x.ID == user.ID);

                Assert.Null(result);
            }
        }
        [Fact]
        public async Task GetUserFromDBAsync()
        {
            DbContextOptions<VacationMVCDbContext> options = new DbContextOptionsBuilder<VacationMVCDbContext>()
                .UseInMemoryDatabase("GetUserFromDBAsync")
                .Options;

            using (VacationMVCDbContext context = new VacationMVCDbContext(options))
            {
                UserService service = new UserService(context);
                User user = new User();
                user.ID = 6;
                user.Name = "Goopty";
                user.FaveTripItem = User.TripItem.Headphones;

                context.Add(user);
                await context.SaveChangesAsync();

                var result = service.GetUser(user.ID);

                Assert.Equal("Goopty", result.Result.Name);
            }
        }
        #endregion
        #region MVC Tests
        [Fact]
        public async void UserDetailsControllerRouteCheck()
        {
            DbContextOptions<VacationMVCDbContext> options = new DbContextOptionsBuilder<VacationMVCDbContext>()
                .UseInMemoryDatabase("UserDetailsRouteCheck")
                .Options;
            using (VacationMVCDbContext context = new VacationMVCDbContext(options))
            {
                UserService service = new UserService(context);
                User user = new User();
                user.ID = 7;
                user.Name = "Mloopty";
                user.FaveTripItem = User.TripItem.Snowboard;
                context.Add(user);
                await context.SaveChangesAsync();

                UserController controller = new UserController(service);
                var result = await controller.Details(user.ID) as ViewResult;
                User resultUser = (User)result.ViewData.Model;

                Assert.Equal("Mloopty", resultUser.Name);
            }
        }
        [Fact]
        public async void UserEditControllerRouteCheck()
        {
            DbContextOptions<VacationMVCDbContext> options = new DbContextOptionsBuilder<VacationMVCDbContext>()
                .UseInMemoryDatabase("UserEditRouteCheck")
                .Options;
            using (VacationMVCDbContext context = new VacationMVCDbContext(options))
            {
                UserService service = new UserService(context);
                User user = new User();
                user.ID = 8;
                user.Name = "Loopty";
                user.FaveTripItem = User.TripItem.Toothpaste;
                context.Add(user);
                await context.SaveChangesAsync();

                UserController controller = new UserController(service);
                var result = await controller.Edit(user.ID) as ViewResult;
                User resultUser = (User)result.ViewData.Model;

                Assert.Equal("Loopty", resultUser.Name);
            }
        }
        [Fact]
        public async void UserDeleteControllerRouteCheck()
        {
            DbContextOptions<VacationMVCDbContext> options = new DbContextOptionsBuilder<VacationMVCDbContext>()
                .UseInMemoryDatabase("UserDeleteRouteCheck")
                .Options;
            using (VacationMVCDbContext context = new VacationMVCDbContext(options))
            {
                UserService service = new UserService(context);
                User user = new User();
                user.ID = 9;
                user.Name = "Roopty";
                user.FaveTripItem = User.TripItem.Volleyball;
                context.Add(user);
                await context.SaveChangesAsync();

                UserController controller = new UserController(service);
                var result = await controller.Delete(user.ID) as ViewResult;
                User resultUser = (User)result.ViewData.Model;

                Assert.Equal("Roopty", resultUser.Name);
            }
        }
        [Fact]
        public async void UserCreateControllerTest()
        {
            DbContextOptions<VacationMVCDbContext> options = new DbContextOptionsBuilder<VacationMVCDbContext>()
                .UseInMemoryDatabase("UserDeleteRouteCheck")
                .Options;
            using (VacationMVCDbContext context = new VacationMVCDbContext(options))
            {
                UserService service = new UserService(context);
                User user = new User();
                user.ID = 10;
                user.Name = "Droopty";
                user.FaveTripItem = User.TripItem.Toothpaste;

                UserController controller = new UserController(service);
                await controller.Create(user);
                var result = await context.Users.FirstOrDefaultAsync(x => x.ID == user.ID);

                Assert.Equal("Droopty", result.Name);
            }
        }
        #endregion
    }
}
