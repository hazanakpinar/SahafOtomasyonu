using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MVC_CORE_PROJE.Models;

namespace MVC_CORE_PROJE.ModelConfigurations
{
    public class YayinEvi_CFG : IEntityTypeConfiguration<YayinEvi>
    {
        public void Configure(EntityTypeBuilder<YayinEvi> builder)
        {
            builder.Property(x => x.YayinEviAdi).HasColumnType("nvarchar").HasMaxLength(50).IsRequired();
            builder.Property(x => x.Adres).HasColumnType("nvarchar").HasMaxLength(150).IsRequired();
            builder.HasData(
                new YayinEvi { YayinEviID = 1, YayinEviAdi = "Aylak Yayınları", Adres = "İstanbul, Beyoğlu" },
    new YayinEvi { YayinEviID = 2, YayinEviAdi = "Karakış Yayıncılık", Adres = "Ankara, Çankaya" },
    new YayinEvi { YayinEviID = 3, YayinEviAdi = "Denizaltı Yayınları", Adres = "İzmir, Konak" },
    new YayinEvi { YayinEviID = 4, YayinEviAdi = "Sonsuz Sayfalar", Adres = "Bursa, Nilüfer" },
    new YayinEvi { YayinEviID = 5, YayinEviAdi = "Efsane Yayıncılık", Adres = "Antalya, Muratpaşa" },
    new YayinEvi { YayinEviID = 6, YayinEviAdi = "Mavi Gece Yayınları", Adres = "Adana, Seyhan" },
    new YayinEvi { YayinEviID = 7, YayinEviAdi = "Kültür Yayınevi", Adres = "Eskişehir, Odunpazarı" },
    new YayinEvi { YayinEviID = 8, YayinEviAdi = "Yıldızlar Yayıncılık", Adres = "Kayseri, Melikgazi" },
    new YayinEvi { YayinEviID = 9, YayinEviAdi = "Hayal Dünyası", Adres = "Sakarya, Adapazarı" },
    new YayinEvi { YayinEviID = 10, YayinEviAdi = "Rüya Yayınları", Adres = "Konya, Selçuklu" }
                );
        }
    }
}
