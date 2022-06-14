using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace ProjektNET.Models
{
    public class Message : IdentityUser
    {

        public int Id { get; set; }

        [Display(Name = "Wiadomość")]
        [Required, StringLength(100)]
        public string? Value { get; set; }

        public string? AdvertizerId { get; set; }

        public string? ClientId { get; set; }
    }
}