using ProjektNET.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using System.ComponentModel.DataAnnotations;

namespace ProjektNET.Pages
{
    [AllowAnonymous]
    public class AddOfferModel : PageModel
    {
        private readonly Data.OfferDBContext _context;

        public AddOfferModel(Data.OfferDBContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        public Offer? Offer { get; set; }

        [BindProperty]
        public InputModel Input { get; set; }
        public class InputModel
        {
            [Required]
            public string Description { get; set; }
 
            [Required]
            public string Category { get; set; }
        }
        public string ReturnUrl { get; set; }
 
        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl ??= Url.Content("~/");
 
            var offer = _context.Offer.FirstOrDefault(f => f.Description == Offer.Description);
            if (offer != null)
            {
                ModelState.AddModelError(string.Empty, Offer.Description + " Jest już wystawiony" );
                return Page();
            } 
            else
            {
                offer = new Offer { Description = Offer.Description, Category = Offer.Category, Advertizer = Offer.Advertizer, Active = Offer.Active };
                _context.Add(offer);
                await _context.SaveChangesAsync();
                return RedirectToPage("AddOfferConfirmation");
            }

            return Page();  
        }
    }
}