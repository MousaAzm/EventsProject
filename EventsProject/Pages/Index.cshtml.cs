using EventsProject.Data;
using EventsProject.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace EventsProject.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly EventContext _context;
        private readonly UserManager<EventsUser> _userManager;

        public IndexModel(ILogger<IndexModel> logger, EventContext context, UserManager<EventsUser> userManager)
        {
            _logger = logger;
            _context = context;
            _userManager = userManager;
        }

        public void OnGet()
        {

        }
    }
}
