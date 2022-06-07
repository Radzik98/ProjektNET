using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjektNET.Data;
using System.Linq;
 
namespace ProjektNET.Pages
{
    [AllowAnonymous]
    public class RegisterConfirmationModel : PageModel
    {
 
        private readonly UserDbContext Db;
 
        public RegisterConfirmationModel(UserDbContext Db)
        {
            this.Db = Db;
        }
 
        public string Email { get; set; }
 
 
        public async Task<IActionResult> OnGetAsync(string email)
        {
            if (email == null)
            {
                return RedirectToPage("/Index");
            }
 
            var user = Db.User.Where(f=> f.Email==email).FirstOrDefault() ;
            if (user == null)
            {
                return NotFound($"Unable to load user with email '{email}'.");
            }
 
            Email = email;
 
            return Page();
        }
    }
}