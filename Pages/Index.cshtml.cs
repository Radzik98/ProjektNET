using ProjektNET.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace ProjektNET.Pages
{
    public class IndexModel : PageModel
    {
        readonly ProjektNET.Data.MyDbContext _context;
        public IndexModel(ProjektNET.Data.MyDbContext context)
        {
            _context = context;
        }

        public IList<User>? Users { get; set; }

        public async Task OnGetAsync()
        {
            Users = await _context.User.ToListAsync();
        }

        public async Task<IActionResult> OnPostCreateAsync()
        {
            return RedirectToPage("./Register");
        }

    }
}