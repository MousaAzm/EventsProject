using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EventsProject.Data;
using EventsProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace EventsProject.Pages.Administrators
{
    [Authorize (Roles ="Admin")]
    public class ManageusersModel : PageModel
    {
        private readonly EventContext _context;
        private readonly UserManager<EventsUser> _userManager;

        public ManageusersModel(EventContext context, UserManager<EventsUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }



        public ICollection<EventsUser> UsersList { get; set; }
        public EventsUser UserRole { get; set; }
        

        public async Task<IActionResult> OnGetAsync()
        {
            UsersList = await _context.Users.ToListAsync();
            return Page();
        }


        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            UsersList = await _context.Users.ToListAsync();
            UserRole = await _context.Users
               .Where(u => u.Id == id)
               .FirstOrDefaultAsync();


            if (!_userManager.IsInRoleAsync(UserRole, "Organizer").Result)
            {
                await _userManager.AddToRoleAsync(UserRole, "Organizer");
                await _context.SaveChangesAsync();
            }
            else
            {
                await _userManager.RemoveFromRoleAsync(UserRole, "Organizer");
                await _context.SaveChangesAsync();
            }


            return Page();

        }


    }
}
