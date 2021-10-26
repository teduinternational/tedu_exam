using System.ComponentModel.DataAnnotations;
using Identity.Shared.Configuration.Configuration.Identity;

namespace Identity.STS.Identity.ViewModels.Account
{
    public class ForgotPasswordViewModel
    {
        [Required]
        public LoginResolutionPolicy? Policy { get; set; }
        
        [EmailAddress]
        public string Email { get; set; }

        public string Username { get; set; }
    }
}
