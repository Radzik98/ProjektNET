using System.ComponentModel.DataAnnotations;

namespace ProjektNET.Models
{
    public class Register
    {
        [Display(Name = "Enter your name:")]
        //[Required()]
        public string Name { get; set; }
    }
}