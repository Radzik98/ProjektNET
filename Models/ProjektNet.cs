using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace ProjektNET.Models
{
    public class ProjektNet
    {
        [Display(Name = "Twój szczęśliwy numerek")]
        [Required, Range(1, 1000, ErrorMessage = "Oczekiwana wartość {0} z zakresu {1} i {2}.")]
        public int? Number { get; set; }
    }
}