using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace _Net_Core_IdentityServer4.Models
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Adını yazın")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Soyadını yazın")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Telefon numarası yazın")]
        [Display(Name = "Telefon numarası")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Telefon numarası doğru değil")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Email adresini yazın")]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Şifreyi yazın")]
        [StringLength(100, ErrorMessage = "{0} en az {2} ve en fazla {1} karakter uzunluğunda olmalıdır.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "Şifre ve onay şifresi eşleşmiyor.")]
        public string ConfirmPassword { get; set; }


        [Required(ErrorMessage = "Lütfen rolü seçin")]
        public string UserRole { get; set; }

        public List<SelectListItem> RoleLists { set; get; }
    }
}
