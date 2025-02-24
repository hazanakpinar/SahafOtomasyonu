using AutoMapper;
using MVC_CORE_PROJE.Areas.CalisanPanel.Models.ViewModels;
using MVC_CORE_PROJE.Models;
using MVC_CORE_PROJE.Models.DTOs;
using MVC_CORE_PROJE.Models.ViewModels;

namespace MVC_CORE_PROJE.Mapper
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<Kitap, Kitap_DTO>().ReverseMap();
            CreateMap<Kitap, Kitap_VM>().ReverseMap();
            CreateMap<Kitap, KitapEkle_VM>().ReverseMap();
            CreateMap<Kitap, KitapGuncelle_DTO>().ReverseMap();

            CreateMap<KitapEkle_VM, Kitap_DTO>().ReverseMap();


            //.ForMember(dest => dest.YazarIDleri, opt => opt.MapFrom(src => src.YazarIDleri))

        }

    }
}
