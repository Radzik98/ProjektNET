using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using ProjektNET.Models;
using System.Threading.Tasks;
using System.Security.Claims;
using ProjektNET.Services;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjektNET.Data;

namespace ProjektNET.Pages
{
    public class ResetPassword : PageModel
    {
        
        [BindProperty]
        public ResetPasswordModel _resetPasswordModel { get; set; }
        private readonly UserDbContext Db;

        public ResetPasswordModel model;
 
        [AllowAnonymous]
        public async Task OnGet(string email)
        {
            model = new ResetPasswordModel { Email = email };
            // var page = Page();
        }
 
        public IActionResult ResetThatPassword(string email)
        {
            model = new ResetPasswordModel { Email = email };
            return Page();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> ResetThatPassword()
        {
            
            if (!ModelState.IsValid)
                return Page();
 
            var user = Db.User.FirstOrDefault(f => f.Email == _resetPasswordModel.Email);
 
            user.Password =  _resetPasswordModel.Password;
 
            return Redirect("/ResetPasswordConfirmation");
        }
    }
}