using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EventsProject.Data;
using EventsProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EventsProject.Pages.Organizers
{
    [Authorize]
    public class CreateModel : PageModel
    {
        private readonly EventContext _context;

        public CreateModel(EventContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Event Event { get; set; }

       
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Events.Add(Event);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}