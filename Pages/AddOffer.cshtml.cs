using ProjektNET.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using System.ComponentModel.DataAnnotations;

namespace ProjektNET.Pages
{
    public class AddOfferModel : PageModel
    {
        private readonly Data.MyDbContext _context;

        private readonly Data.MyDbContext _userContext;

        public AddOfferModel(Data.MyDbContext context, Data.MyDbContext userContext)
        {
            _context = context;
            _userContext = userContext;
        }

        public Offer? Offer { get; set; }

        public User? User { get; set; }

        [BindProperty]
        public InputModel Input { get; set; }
        public class InputModel
        {
            [Required]
            public string Description { get; set; }
 
            [Required]
            public string Category { get; set; }

            [Required]
            public string Location { get; set; }
        }
        public string ReturnUrl { get; set; }
 
        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            User = _userContext.User.FirstOrDefault(m => m.Id == id);
            
            if (User == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            string returnUrl = null;

            returnUrl ??= Url.Content("~/");
 
            var offer = _context.Offer.FirstOrDefault(f => f.Description == Input.Description);
            var user = _userContext.User.FirstOrDefault(f => f.Id == id);

            if (offer != null)
            {
                ModelState.AddModelError(string.Empty, Input.Description + " Jest już wystawiony" );
                return Page();
            } 
            else
            {
                offer = new Offer { Description = Input.Description, Category = Input.Category, Location = Input.Location, Interested = 0, Advertizer = id, Active = true };
                _context.Add(offer);
                await _context.SaveChangesAsync();

                user.IsAdvertizer = true;
                await _userContext.SaveChangesAsync();
                
                return RedirectToPage("AddOfferConfirmation");
            }

            return Page();  
        }
    }
}