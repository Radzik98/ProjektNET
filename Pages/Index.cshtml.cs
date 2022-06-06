using ProjektNET.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ProjektNET.Pages
{
    public class IndexModel : PageModel
    {
        readonly ProjektNET.Data.UserDbContext _context;
        public IndexModel(ProjektNET.Data.UserDbContext context)
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
            //await _context.User.Add();
            return RedirectToPage("./Register");
        }

    }
}