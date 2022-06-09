using ProjektNET.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;

namespace ProjektNET.Pages
{
    [AllowAnonymous]
    public class RegisterModel : PageModel
    {
        private readonly Data.UserDbContext _context;

        public RegisterModel(Data.UserDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public User? User { get; set; }

        public string ReturnUrl { get; set; }
 
        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl ??= Url.Content("~/");
 
            var user = _context.User.FirstOrDefault(f => f.Email == User.Email);
            if (user != null)
            {
                ModelState.AddModelError(string.Empty, User.Email + " Jest już używany" );
                return Page(); 
            } 
            else
            {
                user = new User { Name = User.Name, Surname = User.Surname, Email = User.Email, Password = User.Password };
                _context.Add(user);
                await _context.SaveChangesAsync();
                return RedirectToPage("RegisterConfirmation", new { email = User.Email });
            }

            return Page();  
        }
    }
}