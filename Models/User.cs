using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace ProjektNET.Models
{
    public class User : IdentityUser
    {

        public int Id { get; set; }

        public bool IsAdvertizer { get; set; } = false;

        [Display(Name = "Imię")]
        [Required, StringLength(10)]
        public string? Name { get; set; }

        [Display(Name = "Nazwisko")]
        [Required, StringLength(20)]
        public string? Surname { get; set; }

        [Display(Name = "Adres e-mail")]
        [Required, StringLength(20)]
        public string? Email { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Hasło")]
        [Required, StringLength(10)]
        public string? Password { get; set; }

        [DataType(DataType.Password)]  
        [Display(Name = "Potwierdź hasło")]  
        [Compare("Password", ErrorMessage = "Hasła muszą być takie same.")]
        public string? ConfirmPassword { get; set; }
    }
}