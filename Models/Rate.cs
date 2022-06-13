using System.ComponentModel.DataAnnotations;

namespace ProjektNET.Models
{
    public class Rate
    {

        public int Id { get; set; }

        [Display(Name = "Ocena (1-10)")]
        [Required]
        [Range(0, 10, ErrorMessage = "Podaj liczbę od 1 do 10")]
        public int? RateValue { get; set; }

        [Display(Name = "Twój komentarz (max. 1000 znaków)")]
        [Required, StringLength(1000)]
        public string? Comment { get; set; }
        public int? Advertizer { get; set; }
    }
}