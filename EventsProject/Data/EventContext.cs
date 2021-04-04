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
    public class EventContext : IdentityDbContext<EventsUser>
    {
        public EventContext(DbContextOptions<EventContext> options) : base(options)
        {

        }


        public DbSet<Event> Events { get; set; }
   
        
    }
}