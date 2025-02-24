using System.ComponentModel.DataAnnotations;

namespace MVC_CORE_PROJE.Models
{
    public class Kitap
    {
        public int KitapID { get; set; }
        [Required(ErrorMessage = "Kitap adı zorunludur.")]
        public string KitapAdi { get; set; }
        [Required(ErrorMessage = "Fiyat zorunludur.")]
        public decimal Fiyat { get; set; }
        [Required(ErrorMessage = "Stok zorunludur.")]
        [Range(0, short.MaxValue, ErrorMessage = "Stok negatif olamaz.")]
        public short Stok { get; set; }
        public string? KapakResmi { get; set; }
        [Required(ErrorMessage = "Yayın evi zorunludur.")]
        public  int  YayinEviID { get; set; }
        [Required(ErrorMessage = "Kategori zorunludur.")]
        public  int  KategoriID { get; set; }

        public YayinEvi? YayinEvi {  get; set; }
        public Kategori? Kategori {  get; set; }
        public ICollection<Kitap_Yazar>? Kitap_Yazarlar { get; set; }

    }
}
