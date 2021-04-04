using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EventsProject.Data;
using EventsProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace EventsProject.Pages.Organizers
{
    [Authorize]
    public class DetailsModel : PageModel
    {
        private readonly EventContext _context;

        public DetailsModel(EventContext context)
        {
            _context = context;
        }

        public Event Event { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Event = await _context.Events.FirstOrDefaultAsync(m => m.Id == id);

            if (Event == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
