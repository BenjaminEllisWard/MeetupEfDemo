using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MeetupEfDemo.Data.EF.Data;
using MeetupEfDemo.Data.Repositories;
using MeetupEfDemo.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace MeetupEfDemo.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddHttpContextAccessor();

            // Register EF context
            var connectionString = Configuration.GetConnectionString("DbConnection");
            services.AddDbContext<MeetupEfDemoContext>(options =>
                options.UseSqlServer(connectionString)
            );

            services.AddScoped<IEventService, EventService>();
            services.AddScoped<IEventRepository, EventRepository>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
