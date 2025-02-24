using System.ComponentModel.DataAnnotations;

namespace MVC_CORE_PROJE.Models.DTOs
{
    public class Kitap_DTO
    {
        public string KitapAdi { get; set; }
        public decimal Fiyat { get; set; }
        public short Stok { get; set; }
        public string? KapakResmi { get; set; }
        public int YayinEviID { get; set; }
        public int KategoriID { get; set; }

        // ekstra
        [Required(ErrorMessage = "En az bir yazar seçilmelidir.")]
        [MinLength(1, ErrorMessage = "En az bir yazar seçilmelidir.")]
        public int[] YazarIDleri { get; set; }
    
    }
}
