using MVC_CORE_PROJE.Enums;
using System.ComponentModel.DataAnnotations;

namespace MVC_CORE_PROJE.Models.ViewModels
{
    public class CalisanGuncelle_VM
    {
        public string Id { get; set; }
        [Required(ErrorMessage = "İsim alanı zorunludur.")]
        [RegularExpression("^[a-zA-Z]+$", ErrorMessage = "Yalnızca harf kullanın!")]
        public string Isim { get; set; }
        [Required(ErrorMessage = "İsim alanı zorunludur.")]
        [RegularExpression("^[a-zA-Z]+$", ErrorMessage = "Yalnızca harf kullanın!")]
        public string Soyisim { get; set; }
        [Required(ErrorMessage = "Adres alanı zorunludur.")]
        [StringLength(250, ErrorMessage = "Adres en fazla 250 karakter olmalıdır.")]
        public string Adres { get; set; }
        [Required(ErrorMessage = "Cinsiyet alanı zorunludur.")]
        public Cinsiyet Cinsiyet { get; set; }
        [Required]
        [RegularExpression(@"^(\+90|0)?[ ]?5[0-9]{2}[ ]?[0-9]{3}[ ]?[0-9]{2}[ ]?[0-9]{2}$",
       ErrorMessage = "Geçerli bir telefon numarası giriniz. Örn: +90 555 555 55 55 veya 0555 555 55 55")]
        public string TelefonNumarasi { get; set; }
        [Required(ErrorMessage = "İşe giriş tarihi zorunludur.")]
        public DateTime IseGirisTarihi { get; set; }
        [Required(ErrorMessage = "E-posta adresi zorunludur.")]
        [EmailAddress(ErrorMessage = "Geçerli bir e-posta adresi giriniz. Örn: abc@abc.com")]
        [Display(Name = "E-Posta")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Şifre zorunludur.")]
        [MinLength(6, ErrorMessage = "Şifre en az 6 karakter olmalıdır.")]
        public string Sifre { get; set; }
        [Required(ErrorMessage = "Şifre doğrulama zorunludur.")]
        [Compare("Sifre", ErrorMessage = "Şifreler eşleşmiyor.")]
        public string SifreDogrulama { get; set; }
        [Required]
        public bool AktifMi { get; set; }
    }
}
