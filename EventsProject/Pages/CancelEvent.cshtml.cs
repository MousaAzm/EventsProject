using EventsProject.Data;
using EventsProject.Models;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MimeKit;
using MimeKit.Text;
using System.Linq;
using System.Threading.Tasks;

namespace EventsProject.Pages
{
    [Authorize]
    public class CancelEventModel : PageModel
    {
        private readonly EventContext _context;
        private readonly UserManager<EventsUser> _userManager;
        private readonly SmtpSettings _smtpS;

        public CancelEventModel(EventContext context, UserManager<EventsUser> userManager, SmtpSettings smtpS)
        {
            _smtpS = smtpS;
            _context = context;
            _userManager = userManager;
        }

        [BindProperty]
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
            if (id == null)
            {
                return NotFound();
            }

            Event = await _context.Events.FirstOrDefaultAsync(e => e.Id == id);

            var userId = _userManager.GetUserId(User);
            var user = await _context.Users
                .Where(u => u.Id == userId)
                .FirstOrDefaultAsync();

            if (user == null)
            {
                return NotFound();
            }

            if (_userManager.IsInRoleAsync(user, "Organizer").Result)
            {
                await _context.Users.Where(u => u.Id == userId).Include(u => u.HostedEvents).FirstOrDefaultAsync();
                user.HostedEvents.Remove(Event);
                await _context.SaveChangesAsync();

            }

            await _context.Users.Where(u => u.Id == userId).Include(u => u.JoinedEvents).FirstOrDefaultAsync();
            user.JoinedEvents.Remove(Event);
            await _context.SaveChangesAsync();

            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse(_smtpS.Sender));
            email.To.Add(MailboxAddress.Parse(user.Email));
            email.Subject = "Star Event";
            email.Body = new TextPart(TextFormat.Plain) { Text = "Your event canceled. We hope you come back soon and join our events. Have a nice day" };

            using var smtp = new SmtpClient();
            await smtp.ConnectAsync(_smtpS.SmtpServer, _smtpS.Port, SecureSocketOptions.StartTls);
            await smtp.AuthenticateAsync(_smtpS.UserName, _smtpS.Password);
            await smtp.SendAsync(email);
            await smtp.DisconnectAsync(true);

            return RedirectToPage("/MyEvents");

        }


    }
}
