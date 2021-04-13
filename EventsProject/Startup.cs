using EventsProject.Data;
using EventsProject.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace EventsProject
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
            services.AddRazorPages();



            services.AddDbContext<EventContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("EventsDBConnection")));

            var smtpSettings = Configuration.GetSection("SmtpSettings").Get<SmtpSettings>();
            services.AddSingleton(smtpSettings);


            services.AddDefaultIdentity<EventsUser>()
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<EventContext>()
                .AddDefaultTokenProviders();

            services.ConfigureApplicationCookie(options =>
            options.LoginPath = "/Account/Login"

            );


        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");

                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}
