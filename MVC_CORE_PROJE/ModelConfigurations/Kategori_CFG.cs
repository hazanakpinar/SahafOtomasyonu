using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MVC_CORE_PROJE.Models;

namespace MVC_CORE_PROJE.ModelConfigurations
{
    public class Kategori_CFG : IEntityTypeConfiguration<Kategori>
    {
        public void Configure(EntityTypeBuilder<Kategori> builder)
        {
            builder.Property(x => x.KategoriAdi).HasColumnType("nvarchar").HasMaxLength(20).IsRequired();
            builder.HasData(
                  new Kategori { KategoriID = 1, KategoriAdi = "Roman" },
    new Kategori { KategoriID = 2, KategoriAdi = "Bilim Kurgu" },
    new Kategori { KategoriID = 3, KategoriAdi = "Fantastik" },
    new Kategori { KategoriID = 4, KategoriAdi = "Kişisel Gelişim" },
    new Kategori { KategoriID = 5, KategoriAdi = "Tarih" },
    new Kategori { KategoriID = 6, KategoriAdi = "Biyografi" },
    new Kategori { KategoriID = 7, KategoriAdi = "Şiir" },
    new Kategori { KategoriID = 8, KategoriAdi = "Çocuk Kitapları" },
    new Kategori { KategoriID = 9, KategoriAdi = "Edebiyat" },
    new Kategori { KategoriID = 10, KategoriAdi = "Hikaye" },
    new Kategori { KategoriID = 11, KategoriAdi = "Mizah" },
    new Kategori { KategoriID = 12, KategoriAdi = "Sosyoloji" },
    new Kategori { KategoriID = 13, KategoriAdi = "Felsefe" },
    new Kategori { KategoriID = 14, KategoriAdi = "Sanat" },
    new Kategori { KategoriID = 15, KategoriAdi = "Gizem" }
                );
        }
    }
}
