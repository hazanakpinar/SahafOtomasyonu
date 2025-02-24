using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MVC_CORE_PROJE.Models;

namespace MVC_CORE_PROJE.ModelConfigurations
{
    public class Kitap_Yazar_CFG : IEntityTypeConfiguration<Kitap_Yazar>
    {
        public void Configure(EntityTypeBuilder<Kitap_Yazar> builder)
        {
            // BookAuthor tablosu için primary key tanımlama
            builder.HasKey(ba => new { ba.Kitap_YazarID });

            // BookAuthor tablosu için ilişkileri tanımlama
            builder.HasOne(ba => ba.Kitap)
                .WithMany(b => b.Kitap_Yazarlar)
                .HasForeignKey(ba => ba.KitapID);

            builder.HasOne(ba => ba.Yazar)
                .WithMany(a => a.Kitap_Yazarlar)
                .HasForeignKey(ba => ba.YazarID);

            builder.HasData(new Kitap_Yazar { Kitap_YazarID = 1, KitapID = 1, YazarID = 1 },
                            new Kitap_Yazar { Kitap_YazarID = 2, KitapID = 1, YazarID = 2 },
                            new Kitap_Yazar { Kitap_YazarID = 3, KitapID = 2, YazarID = 2 },
                            new Kitap_Yazar { Kitap_YazarID = 4, KitapID = 3, YazarID = 3 },
                            new Kitap_Yazar { Kitap_YazarID = 5, KitapID = 4, YazarID = 1 },
                            new Kitap_Yazar { Kitap_YazarID = 6, KitapID = 4, YazarID = 4 },
                            new Kitap_Yazar { Kitap_YazarID = 7, KitapID = 4, YazarID = 5 },
                            new Kitap_Yazar { Kitap_YazarID = 8, KitapID = 5, YazarID = 5 },
                            new Kitap_Yazar { Kitap_YazarID = 9, KitapID = 6, YazarID = 5 },
                            new Kitap_Yazar { Kitap_YazarID = 10, KitapID = 7, YazarID = 4 },
                            new Kitap_Yazar { Kitap_YazarID = 11, KitapID = 8, YazarID = 3 },
                            new Kitap_Yazar { Kitap_YazarID = 12, KitapID = 9, YazarID = 1 },
                            new Kitap_Yazar { Kitap_YazarID = 13, KitapID = 9, YazarID = 2 },
                            new Kitap_Yazar { Kitap_YazarID = 14, KitapID = 9, YazarID = 3 },
                            new Kitap_Yazar { Kitap_YazarID = 15, KitapID = 9, YazarID = 4 },
                            new Kitap_Yazar { Kitap_YazarID = 16, KitapID = 9, YazarID = 5 },
                            new Kitap_Yazar { Kitap_YazarID = 17, KitapID = 10, YazarID = 1 });
        }
    }
}
