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

namespace EventsProject.Pages.Administrators
{
    [Authorize]
    public class ManageusersModel : PageModel
    {
        private readonly EventContext _context;
        private readonly UserManager<EventsUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public ManageusersModel(EventContext context, UserManager<EventsUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }


        

        public IList<EventsUser> EventsUser { get; set; }

        public async Task OnGetAsync()
        {
            EventsUser = await _context.Users.ToListAsync();
        }

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }


            var userId = _userManager.GetUserId(User);

            var user = await _userManager.Users
                .Where(u => u.Id == userId)
                .FirstOrDefaultAsync();

            
               


            return Page();
        }

    }
}
