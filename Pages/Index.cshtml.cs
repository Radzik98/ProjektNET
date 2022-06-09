using ProjektNET.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;

namespace ProjektNET.Pages
{
    //[Authorize]
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
    }
}