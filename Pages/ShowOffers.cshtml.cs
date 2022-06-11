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

        public IEnumerable<Offer>? Offers { get; set; }

        public void sort(string searchString)
        {
            if (!String.IsNullOrEmpty(searchString))
            {
                Offers = Offers.Where(o => o.Category.Contains(searchString));
            }
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