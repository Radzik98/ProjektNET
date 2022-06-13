using ProjektNET.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using ProjektNET.Extensions;

namespace ProjektNET.Pages
{
    public class ShowRatesModel : PageModel
    {
        private readonly Data.RateDbContext _context;
        public ShowRatesModel(Data.RateDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public IEnumerable<Rate>? Rates { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            Rates = await _context.Rate.Where(t => t.Advertizer == id).ToListAsync();
            return Page();
        }
    }
}