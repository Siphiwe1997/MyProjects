using System.ComponentModel.DataAnnotations;

namespace MyJourney.Models.ViewModels
{
    public class UserCreateViewModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
