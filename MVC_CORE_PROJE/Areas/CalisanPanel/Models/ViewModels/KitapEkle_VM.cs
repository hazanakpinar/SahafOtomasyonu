using System.ComponentModel.DataAnnotations;

namespace MVC_CORE_PROJE.Areas.CalisanPanel.Models.ViewModels
{
    public class KitapEkle_VM
    {
        [Required(ErrorMessage = "Kitap adı zorunludur.")]
        public string KitapAdi { get; set; }
        [Required(ErrorMessage = "Fiyat zorunludur.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Fiyat sıfırdan büyük olmalıdır.")]
        public decimal Fiyat { get; set; }
        [Required(ErrorMessage = "Stok zorunludur.")]
        [Range(0, short.MaxValue, ErrorMessage = "Stok negatif olamaz.")]
        public short Stok { get; set; }
        //[Required(ErrorMessage = "Kapak Resmi zorunludur.")]
        public IFormFile? KapakResmi { get; set; }
        [Required(ErrorMessage = "Yayın evi zorunludur.")]
        public int YayinEviID { get; set; }
        [Required(ErrorMessage = "Kategori zorunludur.")] 
        public int KategoriID { get; set; }

        [Required(ErrorMessage = "En az bir yazar seçilmelidir.")]
        [MinLength(1, ErrorMessage = "En az bir yazar seçilmelidir.")]
        public int[] YazarIDleri { get; set; }

    }
}
