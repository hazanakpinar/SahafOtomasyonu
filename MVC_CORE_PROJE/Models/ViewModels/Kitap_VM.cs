using Microsoft.AspNetCore.Mvc.Rendering;
using MVC_CORE_PROJE.Areas.CalisanPanel.Models.ViewModels;

namespace MVC_CORE_PROJE.Models.ViewModels
{
    public class Kitap_VM
    {
        public KitapEkle_VM Kitap { get; set; }
        public SelectList Yazarlar { get; set; }
    }
}
