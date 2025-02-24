using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MVC_CORE_PROJE.Models;

namespace MVC_CORE_PROJE.ModelConfigurations
{
    public class Kitap_CFG : IEntityTypeConfiguration<Kitap>
    {
        public void Configure(EntityTypeBuilder<Kitap> builder)
        {
            builder.Property(x => x.Fiyat).HasColumnType("money").IsRequired();
            builder.Property(x => x.KitapAdi).HasColumnType("nvarchar").HasMaxLength(30).IsRequired();
            builder.Property(x => x.Stok).HasColumnType("smallint").IsRequired();
            builder.Property(x => x.KapakResmi).HasColumnType("varchar").HasMaxLength(100).IsRequired(false);
            builder.HasData(
    new Kitap { KitapID = 1, KitapAdi = "Kayıp Zamanın İzinde", Fiyat = 29.99m, Stok = 100, KapakResmi = "/resimler/animalspirit.jpg", YayinEviID = 1, KategoriID = 1 },
    new Kitap { KitapID = 2, KitapAdi = "Denizlerin Sesi", Fiyat = 39.99m, Stok = 50, KapakResmi = "/resimler/ataleoftwocities.jpg", YayinEviID = 2, KategoriID = 2 },
    new Kitap { KitapID = 3, KitapAdi = "Gökyüzü Güncesi", Fiyat = 19.99m, Stok = 200, KapakResmi = "/resimler/graphicdesign.jpg", YayinEviID = 1, KategoriID = 1 },
    new Kitap { KitapID = 4, KitapAdi = "Yıldızlar Arasında", Fiyat = 25.50m, Stok = 75, KapakResmi = "/resimler/hackyoureducation.jpg", YayinEviID = 3, KategoriID = 3 },
    new Kitap { KitapID = 5, KitapAdi = "Kalp Atışları", Fiyat = 45.00m, Stok = 30, KapakResmi = "/resimler/hygge.jpg", YayinEviID = 2, KategoriID = 2 },
    new Kitap { KitapID = 6, KitapAdi = "Bir Gün", Fiyat = 15.99m, Stok = 120, KapakResmi = "/resimler/python.jpg", YayinEviID = 1, KategoriID = 1 },
    new Kitap { KitapID = 7, KitapAdi = "Kayıp Şehir", Fiyat = 55.00m, Stok = 40, KapakResmi = "/resimler/springisintheair.jpg", YayinEviID = 4, KategoriID = 4 },
    new Kitap { KitapID = 8, KitapAdi = "Sonsuzluğun Sırları", Fiyat = 30.00m, Stok = 90, KapakResmi = "/resimler/taketherisk.jpg", YayinEviID = 3, KategoriID = 3 },
    new Kitap { KitapID = 9, KitapAdi = "Anılar ve Hayaller", Fiyat = 10.50m, Stok = 150, KapakResmi = "/resimler/thepassionwithin.jpg", YayinEviID = 2, KategoriID = 1 },
    new Kitap { KitapID = 10, KitapAdi = "Gölgedeki Gizem", Fiyat = 65.00m, Stok = 20, KapakResmi = "/resimler/yoursoulisariver.jpg", YayinEviID = 4, KategoriID = 4 }
                );
        }
    }
}
