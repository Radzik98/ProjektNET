using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjektNET.Data;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
 
namespace ProjektNET.Pages
{
    [AllowAnonymous]
    public class LoginModel : PageModel
    {
 
        private readonly UserDbContext Db;
 
        public LoginModel(UserDbContext Db)
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
 
            [Required]
            [DataType(DataType.Password)]
            public string Password { get; set; }
 
 
        }
 
        public async Task OnGetAsync(string? returnUrl = null)
        {
            returnUrl ??= Url.Content("~/");
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
 
            ReturnUrl = returnUrl;
        }
 
        public async Task<IActionResult> OnPostAsync(string? returnUrl = null)
        {
            returnUrl ??= Url.Content("~/");
 
            if (ModelState.IsValid)
            {
                var user = Db.User.Where(f => f.Email == Input.Email && f.Password == Input.Password).FirstOrDefault();
                if (user == null)
                {
                    ModelState.AddModelError(string.Empty, "Invalid Email or Password");
                    return Page();
                }
 
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.Name, user.Name),
                };

                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);
                
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                        principal,
                        new AuthenticationProperties { IsPersistent = true });
 
 
                return LocalRedirect(returnUrl);
            }

            return Page();
        }
    }
}