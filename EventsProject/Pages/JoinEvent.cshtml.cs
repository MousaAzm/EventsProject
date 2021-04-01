using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EventsProject.Models;
using EventsProject.Data;

namespace EventsProject.Pages
{
    public class JoinEventModel : PageModel
    {
        private readonly EventContext _context;
        
        public JoinEventModel(EventContext context)
        {
            _context = context;
        }



        [BindProperty]
        //public Attendee Attendee { get; set; }
        public Event Event { get; set; }


        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Event = await _context.Events.FirstOrDefaultAsync(e => e.Id == id);


            if (Event == null)
            {
                return NotFound();
            }
            return Page();
        }


        public async Task<IActionResult> OnPostAsync(int? id)
        {

            //if (id == null)
            //{
            //    return NotFound();
            //}

            //Attendee = await _context.EventsUsers.FirstOrDefaultAsync(a => a.Id == id);
            //Event = await _context.Events.Include(a => a.Attendees).FirstOrDefaultAsync(e => e.Id == id);

            //if (Event == null)
            //{
            //    return NotFound();
            //}

            //var attendee = await _context.Attendees.FirstOrDefaultAsync();

            //if (!Event.Attendees.Contains(attendee))
            //{
            //    Event.Attendees.Add(attendee);
            //    await _context.SaveChangesAsync();
            //}


            return Page();

        }

    }
}

