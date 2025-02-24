namespace MVC_CORE_PROJE.Models
{
    public class Kategori
    {
        public int KategoriID { get; set; }
        public string KategoriAdi { get; set; }
        public ICollection<Kitap>? Kitaplar { get; set; }

    }
}
