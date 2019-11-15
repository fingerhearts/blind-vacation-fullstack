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
        public IHostEnvironment Environment { get; }

        public Startup(IHostEnvironment environment)
        {
            Environment = environment;
            var builder = new ConfigurationBuilder().AddEnvironmentVariables();
            builder.AddUserSecrets<Startup>();
            Configuration = builder.Build();
        }


        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            //string connString = Environment.IsDevelopment()
            //    ? Configuration["ConnectionStrings:DefaultConnection"]
            //    : Configuration["ConnectionStrings:ProductionConnection"];

            //services.AddDbContext<VacationMVCDbContext>(options =>
            //options.UseSqlServer(connString));

            services.AddDbContext<VacationMVCDbContext>(options =>
                 options.UseSqlServer(Configuration["ConnectionStrings:DefaultConnection"]));


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
