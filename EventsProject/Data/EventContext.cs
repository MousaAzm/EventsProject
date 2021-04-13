using EventsProject.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EventsProject.Data
{
    public class EventContext : IdentityDbContext<EventsUser>
    {
        public EventContext(DbContextOptions<EventContext> options) : base(options)
        {

        }


        public DbSet<Event> Events { get; set; }


    }
}