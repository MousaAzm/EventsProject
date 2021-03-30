using EventsProject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventsProject.Data
{
    public class EventContext : DbContext
    {
        public EventContext(DbContextOptions<EventContext> options) : base(options)
        {

        }

        //public DbSet<EventsUser> EventsUsers { get; set; }
        public DbSet<Attendee> Attendees { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Organizer> Organizers { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Attendee>().ToTable("Attendee");
            modelBuilder.Entity<Event>().ToTable("Event");
            modelBuilder.Entity<Organizer>().ToTable("Organizer");

        }

    }
}
