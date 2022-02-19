using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authentication;

namespace _Net_Core_IdentityServer4.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Email adresini yazın")]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Şifreyi yazın")]
        [StringLength(100, ErrorMessage = "{0} en az {2} ve en fazla {1} karakter uzunluğunda olmalıdır.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        public string ReturnUrl { get; set; }
    }
}
