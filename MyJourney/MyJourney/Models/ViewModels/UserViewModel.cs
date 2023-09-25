using System.ComponentModel.DataAnnotations;

namespace MyJourney.Models.ViewModels
{
    public class LoginModel
    {

        [Required]
        public string Name { get; set; }

        [Required]
        [UIHint("password")]
        public string Password { get; set; }

        public string ReturnUrl { get; set; } = "/";

        //If the user checks the Remember Me box, the app
        //uses a persistent cookie to keep the user logged
        //in across multiple sessions.Otherwise, the app
        //uses a session cookie that expires at the end of
        //the session.
        public bool RememberMe { get; set; }
    }

    public class RegisterModel
    {
        [Required]
        [Display(Name = "User name")]
        public string UserName { get; set; }

        [Required]
        [Display(Name = "E-mail")]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)] //Indicate that password options specified in Program.cs must be used.
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Passwords must match")]
        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
}
