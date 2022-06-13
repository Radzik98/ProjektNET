using ProjektNET.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using ProjektNET.Extensions;

namespace ProjektNET.Pages
{
    public class ShowAdvertizerModel : PageModel
    {
        private readonly Data.UserDbContext _context;
        public ShowAdvertizerModel(Data.UserDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public IEnumerable<User>? Users { get; set; }

        public async Task OnGetAsync()
        {
            Users = await _context.User.ToListAsync();
        }

        public async Task<IActionResult> OnPostRateAsync(int? id)
        {
            return Redirect("~/RateAdvertizer/" + id);
        }

        public async Task<IActionResult> OnPostShowOpinionsAsync(int? id)
        {
            return Redirect("~/ShowRates/" + id);
        }
    }
}