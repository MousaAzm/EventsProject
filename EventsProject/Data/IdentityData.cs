using EventsProject.Models;
using Microsoft.AspNetCore.Identity;
using System;

namespace EventsProject.Data
{
    public static class IdentityData
    {


        public static void SeedData(EventContext context,
            UserManager<EventsUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            SeedEvents(context);
            SeedRoles(roleManager);
            SeedUsers(userManager);
        }

        private static void SeedEvents(EventContext context)
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();


            var events = new Event[]
            {
                new Event{Title="Hapyy Night", Address="Västra Hamngatan 5",Date=DateTime.Now.AddDays(34), Place="Sweden",  Description= "Two night live Concert with best music groups"},
                new Event{Title="Star Club", Address="Östra Hamngatan",Date=DateTime.Now.AddDays(12), Place="Sweden",  Description= "A party with population DJ"},
                new Event{Title="Night Party", Address="Södra Larmgatan 4",Date=DateTime.Now.AddDays(15), Place="Sweden",  Description= "Night Party with free drinks"},
                new Event{Title="Great Party", Address="Arsenals 2",Date=DateTime.Now.AddDays(24), Place="Spania", Description= "Night Party"},
                new Event{Title="Power Tour" ,Address="Rainbow 3",Date=DateTime.Now.AddDays(11), Place="Spania",  Description= "Summer time danceing "},
                new Event{Title="World Violation", Address="Kingstreet 4",Date=DateTime.Now.AddDays(10), Place="USA",  Description= "Live Concert"},
            };

            context.AddRange(events);
            context.SaveChanges();

        }

        private static void SeedUsers(UserManager<EventsUser> userManager)
        {
            if (userManager.FindByEmailAsync("admin@gmail.com").Result == null)
            {
                EventsUser admin = new EventsUser();
                admin.UserName = "admin@gmail.com";
                admin.Email = "admin@gmail.com";


                IdentityResult result = userManager.CreateAsync(admin, "P@ssw0rd1!").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(admin, "Admin").Wait();
                }
            }

            EventsUser user = new EventsUser();
            user.UserName = "hej@gmail.com";
            user.Email = "hej@gmail.com";


            IdentityResult result2 = userManager.CreateAsync(user, "/6vQd6USL,i_wB&").Result;
        }

        private static void SeedRoles(RoleManager<IdentityRole> roleManager)
        {

            if (!roleManager.RoleExistsAsync("Admin").Result)
            {
                IdentityRole adminRole = new IdentityRole();
                adminRole.Name = "Admin";
                IdentityResult roleResult1 = roleManager.
                CreateAsync(adminRole).Result;
            }

            if (!roleManager.RoleExistsAsync("Organizer").Result)
            {
                IdentityRole organizerRole = new IdentityRole();
                organizerRole.Name = "Organizer";
                IdentityResult roleResult2 = roleManager.
                CreateAsync(organizerRole).Result;
            }

        }


    }
}
