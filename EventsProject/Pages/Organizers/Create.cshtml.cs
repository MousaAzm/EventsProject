using EventsProject.Data;
using EventsProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace EventsProject.Pages.Organizers
{
    [Authorize(Roles = "Organizer")]
    public class CreateModel : PageModel
    {
        private readonly EventContext _context;
        private readonly UserManager<EventsUser> _userManager;

        public CreateModel(EventContext context, UserManager<EventsUser> userManager)
        {
            _context = context;
            _userManager = userManager;
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
            var userId = _userManager.GetUserId(User);
            var user= _context.Users
                .Where(u => u.Id == userId )
                .Include(u => u.HostedEvents)
                .FirstOrDefaultAsync();

            Event.Organizer = user.Result;

            _context.Events.Add(Event);
            await _context.SaveChangesAsync();

            return RedirectToPage("./OrganizeEvents");
        }
    }
}