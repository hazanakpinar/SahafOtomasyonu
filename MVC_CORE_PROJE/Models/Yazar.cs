namespace MVC_CORE_PROJE.Models
{
    public class Yazar
    {
        public int YazarID { get; set; }
        public string YazarAdi { get; set; }
        public ICollection<Kitap_Yazar>? Kitap_Yazarlar { get; set; }
    }
}
