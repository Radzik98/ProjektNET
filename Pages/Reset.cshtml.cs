using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjektNET.Data;
using ProjektNET.Services;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using ProjektNET.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
 
namespace ProjektNET.Pages
{
    [AllowAnonymous]
    public class ResetModel : PageModel
    {
        private UserManager<User> userManager;

        private readonly UserDbContext Db;
 
        public ResetModel(UserDbContext Db)
        {
            this.Db = Db;
        }
 
        [BindProperty]
        public InputModel Input { get; set; }
 
        public string ReturnUrl { get; set; }
 
        public class InputModel
        {
            [Required]
            [EmailAddress]
            public string Email { get; set; }
 
        }
 
        
        public async Task OnGetAsync(string? returnUrl = null)
        {
            returnUrl ??= Url.Content("~/"); 
            ReturnUrl = returnUrl;
        }
 
        public async Task<IActionResult> OnPostAsync(string? returnUrl = null)
        {
            returnUrl ??= Url.Content("~/");
 
            if (ModelState.IsValid)
            {
                var user = Db.User.Where(f => f.Email == Input.Email).FirstOrDefault();
                if (user == null)
                {
                    ModelState.AddModelError(string.Empty, "Invalid Email");
                    return Page();
                }
                
                var link = "https://localhost:7222/ResetPassword?email=" + user.Email;

                //var link = Url.Action("ResetPassword", null, new { email = user.Email }, Request.Scheme);
                EmailSender emailSender = new EmailSender();
                bool emailResponse = emailSender.SendEmailPasswordReset(user.Email, link);
    
                if (emailResponse)
                    return Redirect("/ResetConfirmation");
                else
                {
                    // log email failed 
                }
                return Page();
            }

            return Page();
        }
    }
}