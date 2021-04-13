using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

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
