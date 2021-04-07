using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventsProject.Models
{
    public class EventsUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        

        public ICollection<Event> HostedEvents { get; set; }
        public ICollection<Event> JoinedEvents { get; set; }
    }
}
