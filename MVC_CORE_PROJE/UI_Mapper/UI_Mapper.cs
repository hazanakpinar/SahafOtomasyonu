using AutoMapper;
using MVC_CORE_PROJE.Areas.CalisanPanel.Models.ViewModels;
using MVC_CORE_PROJE.Models.DTOs;

namespace MVC_CORE_PROJE.UI_Mapper
{
    public class UI_Mapper:Profile
    {
        public UI_Mapper()
        {
            CreateMap<KitapEkle_VM, Kitap_DTO>().ReverseMap();
        }
       
    }
}
