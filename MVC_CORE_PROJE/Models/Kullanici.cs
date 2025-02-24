using Microsoft.AspNetCore.Identity;
using MVC_CORE_PROJE.Enums;

namespace MVC_CORE_PROJE.Models
{
    public class Kullanici : IdentityUser<int>
    {
        public string Isim { get; set; }
        public string Soyisim { get; set; }
        public string Adres { get; set; }
        public Cinsiyet Cinsiyet { get; set; }
        public DateTime IseGirisTarihi { get; set; }
        public bool AktifMi { get; set; }

        //Nav Property
    }
}
