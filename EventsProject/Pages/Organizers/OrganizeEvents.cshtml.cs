using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EventsProject.Data;
using EventsProject.Models;
using Microsoft.AspNetCore.Authorization;

namespace EventsProject.Pages.Organizers
{
    [Authorize]
    public class OrganizeEventsModel : PageModel
    {
        private readonly EventContext _context;

        public OrganizeEventsModel(EventContext context)
        {
            _context = context;
        }

        public IList<Event> Event { get;set; }

        public async Task OnGetAsync()
        {
            Event = await _context.Events.ToListAsync();
        }
    }
}
