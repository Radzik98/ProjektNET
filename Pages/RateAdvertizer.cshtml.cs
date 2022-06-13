using ProjektNET.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;

namespace ProjektNET.Pages
{
    [AllowAnonymous]
    public class RateAdvertizerModel : PageModel
    {
        private readonly Data.RateDbContext _context;

        public RateAdvertizerModel(Data.RateDbContext context)
        {
            _context = context;
        }

        private int? AdvertizerId;

        [BindProperty]
        public Rate? Rate { get; set; }
        public IActionResult OnGet(int? id)
        {
            AdvertizerId = id;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl ??= Url.Content("~/");
 
            //var rate = _context.Rate.FirstOrDefault(f => f.Id = Rate.Id);
            var rate = new Rate { RateValue = Rate.RateValue, Comment = Rate.Comment, Advertizer = AdvertizerId };
            
            _context.Add(rate);
            await _context.SaveChangesAsync();
            return RedirectToPage("ShowAdvertizers");
        }
    }
}