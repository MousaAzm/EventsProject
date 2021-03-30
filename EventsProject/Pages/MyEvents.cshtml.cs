using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EventsProject.Data;
using EventsProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace EventsProject.Pages
{
    public class MyEventsModel : PageModel
    {
        private readonly EventContext _context;

        public MyEventsModel(EventContext context)
        {
            _context = context;
        }

        public IList<Event> Event { get; set; }

        public async Task OnGetAsync()
        {
            var attendee = await _context.Attendees.Include(a => a.Events)
                .ThenInclude(o => o.Organizer)
                .FirstOrDefaultAsync();
            Event = attendee.Events;
        }

    }
}
