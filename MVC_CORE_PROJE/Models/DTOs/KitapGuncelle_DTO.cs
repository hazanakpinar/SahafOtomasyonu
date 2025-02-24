namespace MVC_CORE_PROJE.Models.DTOs
{
    public class KitapGuncelle_DTO
    {
        public int KitapID { get; set; }
        public string KitapAdi { get; set; }
        public decimal Fiyat { get; set; }
        public short Stok { get; set; }
        public string? KapakResmi { get; set; }
        public int YayinEviID { get; set; }
        public int KategoriID { get; set; }

    }
}
