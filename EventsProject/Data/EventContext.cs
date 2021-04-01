using EventsProject.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventsProject.Data
{
    public class EventContext : IdentityDbContext<IdentityUser>
    {
        public EventContext(DbContextOptions<EventContext> options) : base(options)
        {

        }

        public DbSet<EventsUser> EventsUsers { get; set; }
        public DbSet<Event> Events { get; set; }

        

        public void Seeding()
        {

            Database.EnsureDeleted();
            Database.EnsureCreated();


            var admin = new EventsUser[]
            {
                new EventsUser{
                    UserName="admin",
                    FirstName="Björn",
                    LastName="Strömberg",
                    Email="björn.strömberg@gmai.com",
                    EmailConfirmed=true,
                    PhoneNumber="0978435435",
                    
                }
            };

            EventsUsers.AddRange(admin);
            SaveChanges();

            var events = new Event[]
            {
            new Event{Title="Hapyy Night", Address="Västra Hamngatan 5",Date=DateTime.Now.AddDays(34), Place="Sweden",  Description= "Two night live Concert with best music groups"},
            new Event{Title="Star Club", Address="Östra Hamngatan",Date=DateTime.Now.AddDays(12), Place="Sweden",  Description= "A party with population DJ"},
            new Event{Title="Night Party", Address="Södra Larmgatan 4",Date=DateTime.Now.AddDays(15), Place="Sweden",  Description= "Night Party with free drinks"},
            new Event{Title="Great Party", Address="Arsenals 2",Date=DateTime.Now.AddDays(24), Place="Spania", Description= "Night Party"},
            new Event{Title="Power Tour" ,Address="Rainbow 3",Date=DateTime.Now.AddDays(11), Place="Spania",  Description= "Summer time danceing "},
            new Event{Title="World Violation", Address="Kingstreet 4",Date=DateTime.Now.AddDays(10), Place="USA",  Description= "Live Concert"},
            };
            foreach (Event e in events)
            {
                Events.Add(e);
            }
            SaveChanges();

        }



    }
}
