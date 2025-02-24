using System.ComponentModel.DataAnnotations;

namespace IdentityMVCManuel.Models.ViewModels
{
    public class Giris_VM
    {
        [Required(ErrorMessage = "E-posta adresi zorunludur.")]
        [EmailAddress(ErrorMessage = "Geçerli bir e-posta adresi giriniz. Örn: abc@abc.com")]
        [Display(Name = "E-Posta")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Şifre zorunludur.")]
        public string Sifre { get; set; }
    }
}
