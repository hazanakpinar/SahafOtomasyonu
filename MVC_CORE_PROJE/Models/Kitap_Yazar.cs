namespace MVC_CORE_PROJE.Models
{
    public class Kitap_Yazar
    {
        public int Kitap_YazarID { get; set; }
        public int KitapID { get; set; }
        public int YazarID { get; set; }

        //nav prop
        public Kitap? Kitap { get; set; }
        public Yazar? Yazar { get; set; }

    }
}
