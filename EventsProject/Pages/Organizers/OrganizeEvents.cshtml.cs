using EventsProject.Data;
using EventsProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventsProject.Pages.Organizers
{
    [Authorize(Roles = "Organizer")]
    public class OrganizeEventsModel : PageModel
    {
        private readonly EventContext _context;
        private readonly UserManager<EventsUser> _userManager;

        public OrganizeEventsModel(EventContext context, UserManager<EventsUser> userManager)
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
                .Include(u => u.HostedEvents)
                .FirstOrDefaultAsync();

            Event = user.HostedEvents;
        }
    }
}
