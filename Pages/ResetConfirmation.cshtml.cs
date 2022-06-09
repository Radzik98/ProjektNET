using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjektNET.Data;
using System.Linq;
 
namespace ProjektNET.Pages
{
    [AllowAnonymous]
    public class ResetConfirmationModel : PageModel
    {
 
        private readonly UserDbContext Db;
 
        public ResetConfirmationModel(UserDbContext Db)
        {
            this.Db = Db;
        }
 
        public string Email { get; set; }
 
 
        public async Task<IActionResult> OnGetAsync(string? email)
        {
            return Page();
        }
    }
}
