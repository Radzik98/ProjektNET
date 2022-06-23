using ProjektNET.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using System.ComponentModel.DataAnnotations;

namespace ProjektNET.Pages
{
    public class ResetPasswordModel : PageModel
    {
        private readonly ProjektNET.Data.MyDbContext _context;

        public ResetPasswordModel(ProjektNET.Data.MyDbContext context)
        {
            _context = context;
        }

        public User? User { get; set; }
        
        [BindProperty]
        public InputModel Input { get; set; }
        public class InputModel
        {
            [Required]
            [DataType(DataType.Password)]
            public string Password { get; set; }
 
            [Required]
            [DataType(DataType.Password)]
            [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }
 
 
        }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            User = await _context.User.FirstOrDefaultAsync(m => m.Id == id);

            if (User == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? id)
        {
            string? returnUrl = null;
            returnUrl ??= Url.Content("~/");

            User = await _context.User.FirstOrDefaultAsync(m => m.Id == id);

            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (User != null)
            {
                User.Password = Input.Password;
                User.ConfirmPassword = Input.ConfirmPassword;

                _context.Attach(User).State = EntityState.Modified;

                try
                {
                    await _context.SaveChangesAsync();
                    return RedirectToPage("ResetPasswordConfirmation", new { email = User.Email });
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserExists(User.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }

            return RedirectToPage("./Index");
        }

        private bool UserExists(int? id)
        {
            return _context.User.Any(e => e.Id == id);
        }
    }
}
