using ProjektNET.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace ProjektNET.Pages
{
    //[Authorize]
    public class EditModel : PageModel
    {
        private readonly ProjektNET.Data.UserDbContext _context;

        public EditModel(ProjektNET.Data.UserDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public User? User { get; set; }

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
        public async Task<IActionResult> OnPostAsync(string? returnUrl = null)
        {
            returnUrl ??= Url.Content("~/");

            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (User != null)
            {

                _context.Attach(User).State = EntityState.Modified;

                try
                {
                    await _context.SaveChangesAsync();
                    return RedirectToPage("EditConfirmation", new { email = User.Email });
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