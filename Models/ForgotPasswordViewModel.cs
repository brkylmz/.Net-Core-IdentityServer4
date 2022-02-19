using System.ComponentModel.DataAnnotations;

namespace _Net_Core_IdentityServer4.Models
{
    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
