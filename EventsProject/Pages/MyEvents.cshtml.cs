using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EventsProject.Data;
using EventsProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace EventsProject.Pages
{
    [Authorize]
    public class MyEventsModel : PageModel
    {
        private readonly EventContext _context;
        private readonly UserManager<EventsUser> _userManager;

        public MyEventsModel(EventContext context, UserManager<EventsUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public ICollection<Event> Event { get; set; }
       

        public async Task OnGetAsync()
        {
            var userId = _userManager.GetUserId(User);
            var user = await _context.Users
                .Where(u => u.Id == userId)
                .FirstOrDefaultAsync();

            if (_userManager.IsInRoleAsync(user, "Organizer").Result)
            {

                var hostedJoined = await _context.Users
                    .Where(u => u.Id == userId)
                    .Include(e => e.HostedEvents)
                    .FirstOrDefaultAsync();
                Event = user.HostedEvents;
            }
            
                var userJoined = await _context.Users
                   .Where(u => u.Id == userId)
                   .Include(e => e.JoinedEvents)
                   .FirstOrDefaultAsync();
                Event = user.JoinedEvents;
            
        }

    }
}
