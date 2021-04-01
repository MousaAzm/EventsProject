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

        public Event Organizer { get; set; }
        public Event Attendee { get; set; }
    }
}
