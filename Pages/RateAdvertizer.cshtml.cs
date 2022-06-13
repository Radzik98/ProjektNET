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

        public async Task<IActionResult> OnPostAsync(int? id, string returnUrl = null)
        {
            AdvertizerId = id;
            returnUrl ??= Url.Content("~/");
            if(Rate.Comment == null || Rate.RateValue == null)
            {
                return Page();
            }
            //var rate = _context.Rate.FirstOrDefault(f => f.Id = Rate.Id);
            //var rate = _context.Rate.FirstOrDefault(f => f.Id == 1000000000);
            var rate = new Rate { RateValue = Rate.RateValue, Comment = Rate.Comment, Advertizer = AdvertizerId };
            
            _context.Add(rate);
            await _context.SaveChangesAsync();
            return RedirectToPage("ShowAdvertizers");
        }
    }
}