using ProjektNET.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace ProjektNET.Pages
{
    public class ShowOfferModel : PageModel
    {
        private readonly Data.OfferDbContext _context;
        public ShowOfferModel(Data.OfferDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public string? category { get; set; }

        [BindProperty]
        public string? category2 { get; set; }

        [BindProperty]
        public string? description { get; set; }

        [BindProperty]
        public string? location { get; set; }

        [BindProperty]
        public IEnumerable<Offer>? Offers { get; set; }

        public async Task<IActionResult> OnPostSortAsync(string returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");
            if (!String.IsNullOrEmpty(category))
            {
                Offers = _context.Offer.Where(o => o.Category == category);
            }
            else
            {
                Offers = _context.Offer;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostSearchAsync(string returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");
            if (!String.IsNullOrEmpty(category2) || !String.IsNullOrEmpty(description) || !String.IsNullOrEmpty(location))
            {
                Offers = _context.Offer;
                if(!String.IsNullOrEmpty(category2))
                {
                    Offers = Offers.Where(o => o.Category == category2);
                }
                if(!String.IsNullOrEmpty(description))
                {
                    Offers = Offers.Where(o => o.Description == description);
                }
                if(!String.IsNullOrEmpty(location))
                {
                    Offers = Offers.Where(o => o.Location == location);
                }
                
                return Page();
            }
            else
            {
                Offers = _context.Offer;
                return Page();
            }
            // if (!String.IsNullOrEmpty(category2))
            // {
            //     Offers = _context.Offer.Where(o => o.Category == category2);
            // }
            // else
            // {
            //     Offers = _context.Offer;
            // }
            // return Page();
        }

        public async Task OnGetAsync()
        {
            Offers = await _context.Offer.ToListAsync();
        }

        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            var contact = await _context.Offer.FindAsync(id);

            if (contact != null)
            {
                _context.Offer.Remove(contact);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage();
        }
    }
}