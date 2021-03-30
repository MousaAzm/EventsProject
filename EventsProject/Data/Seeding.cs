using EventsProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventsProject.Data
{
    public static class Seeding
    {
        public static void Seed(this EventContext modelBuilder)
        {

            modelBuilder.Database.EnsureCreated();

            if (modelBuilder.Attendees.Any())
            {
                return;
            }

            var attendees = new Attendee[]
            {
            new Attendee{Name="Björn",Email="björn_Strömberg@gmail.com",Phone_Number="045123161"},
            };

            foreach (Attendee s in attendees)
            {
                modelBuilder.Attendees.Add(s);
            }
            modelBuilder.SaveChanges();


            var organizers = new Organizer[]
           {
            new Organizer{Name="Rod Laver Arena",Email="laver_arena@gmail.com",Phone_Number="043123161"},
            new Organizer{Name="Big Time Tour",Email="big_time@gmail.com",Phone_Number="025123161"},
            new Organizer{Name="Alone club",Email="alone_club@gmail.com",Phone_Number="044523161"},
            new Organizer{Name="Wanda's swing",Email="swing225@gmail.com",Phone_Number="06414761"},
            new Organizer{Name="Night Event",Email="night_event@gmail.com",Phone_Number="078123161"},
            new Organizer{Name="Valnd",Email="valnd@gmail.com",Phone_Number="045123161"},
           };
            foreach (Organizer o in organizers)
            {
                modelBuilder.Organizers.Add(o);
            }
            modelBuilder.SaveChanges();

            var events = new Event[]
            {
            new Event{Title="Hapyy Night", OrganizerId=2, Address="Västra Hamngatan 5",Date=DateTime.Now.AddDays(34), Place="Sweden",  Description= "Two night live Concert with best music groups"},
            new Event{Title="Star Club", OrganizerId=1, Address="Östra Hamngatan",Date=DateTime.Now.AddDays(12), Place="Sweden",  Description= "A party with population DJ"},
            new Event{Title="Night Party", OrganizerId=3, Address="Södra Larmgatan 4",Date=DateTime.Now.AddDays(15), Place="Sweden",  Description= "Night Party with free drinks"},
            new Event{Title="Great Party", OrganizerId=4, Address="Arsenals 2",Date=DateTime.Now.AddDays(24), Place="Spania", Description= "Night Party"},
            new Event{Title="Power Tour", OrganizerId=6,Address="Rainbow 3",Date=DateTime.Now.AddDays(11), Place="Spania",  Description= "Summer time danceing "},
            new Event{Title="World Violation",OrganizerId=5, Address="Kingstreet 4",Date=DateTime.Now.AddDays(10), Place="USA",  Description= "Live Concert"},
            };
            foreach (Event e in events)
            {
                modelBuilder.Events.Add(e);
            }
            modelBuilder.SaveChanges();

        }
    }
}
