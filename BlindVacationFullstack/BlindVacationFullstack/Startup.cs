using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlindVacationFullstack.Data;
using BlindVacationFullstack.Models.Interfaces;
using BlindVacationFullstack.Models.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace BlindVacationFullstack
{
    public class Startup

    {
        public IConfiguration Configuration { get; }
        public IWebHostEnvironment WebHostEnvironment { get; }

        public Startup(IWebHostEnvironment webHostEnvironment)
        {
            WebHostEnvironment = webHostEnvironment;
            var builder = new ConfigurationBuilder().AddEnvironmentVariables();
            builder.AddUserSecrets<Startup>();
            Configuration = builder.Build();
        }

        // Source: https://n1ghtmare.github.io/2020-09-28/deploying-a-dockerized-aspnet-core-app-using-a-postgresql-db-to-heroku/
        private string GetHerokuConnectionString(string connectionString)
        {
            string connectionUrl = WebHostEnvironment.IsDevelopment()
                ? Configuration["ConnectionStrings:" + connectionString]
                : Environment.GetEnvironmentVariable(connectionString);

            var databaseUri = new Uri(connectionUrl);

            string db = databaseUri.LocalPath.TrimStart('/');
            string[] userInfo = databaseUri.UserInfo.Split(':', StringSplitOptions.RemoveEmptyEntries);

            return $"User ID={userInfo[0]};Password={userInfo[1]};Host={databaseUri.Host};Port={databaseUri.Port};Database={db};Pooling=true;SSL Mode=Require;Trust Server Certificate=True;";
        }


        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            services.AddDbContext<VacationMVCDbContext>(options => options.UseNpgsql(GetHerokuConnectionString("VACATION_PURPLE")));

            services.AddScoped<IUserManager, UserService>();

            services.AddScoped<ITripManager, TripService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseStaticFiles();

            app.UseEndpoints(endpoints =>
            {
                    endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
