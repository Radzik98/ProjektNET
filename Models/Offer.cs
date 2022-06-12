using System.ComponentModel.DataAnnotations;

namespace ProjektNET.Models
{
    public class Offer
    {

        public int Id { get; set; }

        [Display(Name = "Treść (max 40 znaków)")]
        [Required, StringLength(100)]
        public string? Description { get; set; }

        [Display(Name = "Kategoria")]
        [Required, StringLength(20)]
        public string? Category { get; set; }

        [Display(Name = "Lokalizacja")]
        [Required, StringLength(20)]
        public string? Location { get; set; }

        public int? Interested { get; set; }

        public int? Advertizer { get; set; }

        public bool? Active { get; set; }
    }
}