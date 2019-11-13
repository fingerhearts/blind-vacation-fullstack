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
            user.FaveColor = User.Color.Blue;

            Assert.Equal(1, user.ID);
            Assert.Equal("Hoopty", user.Name);
            Assert.Equal(User.Color.Blue, user.FaveColor);
        }
        [Fact]
        public void GetterSetterTestTrip()
        {
            Trip trip = new Trip();
            trip.UserID = 2;
            trip.RecommendationCode = 1234;
            trip.Name = "Woopty";

            Assert.Equal(2, trip.UserID);
            Assert.Equal(1234, trip.RecommendationCode);
            Assert.Equal("Woopty", trip.Name);
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
                user.FaveColor = User.Color.White;

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
                user.FaveColor = User.Color.Pink;

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
                user.FaveColor = User.Color.Gold;

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
                user.FaveColor = User.Color.Brown;

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
                user.FaveColor = User.Color.Black;
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
                user.FaveColor = User.Color.Cyan;
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
                user.FaveColor = User.Color.Green;
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
                user.FaveColor = User.Color.Green;

                UserController controller = new UserController(service);
                await controller.Create(user);
                var result = await context.Users.FirstOrDefaultAsync(x => x.ID == user.ID);

                Assert.Equal("Droopty", result.Name);
            }
        }
        #endregion
    }
}
