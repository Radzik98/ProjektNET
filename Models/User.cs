using System.ComponentModel.DataAnnotations;

namespace ProjektNET.Models
{
    public class User
    {
        public int Id { get; set; }

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