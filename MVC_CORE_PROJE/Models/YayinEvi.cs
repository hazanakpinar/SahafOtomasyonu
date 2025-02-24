namespace MVC_CORE_PROJE.Models
{
    public class YayinEvi
    {
        public int YayinEviID { get; set; }
        public string YayinEviAdi { get; set; }
        public string Adres { get; set; }
        public ICollection<Kitap>? Kitaplar { get; set; }

    }
}
