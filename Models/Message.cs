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

        public int? AdvertizerId { get; set; }

        public int? ClientId { get; set; }

        public int? SenderId { get; set; }
    }
}