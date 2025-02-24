using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MVC_CORE_PROJE.Models;

namespace MVC_CORE_PROJE.ModelConfigurations
{
    public class Yazar_CFG : IEntityTypeConfiguration<Yazar>
    {
        public void Configure(EntityTypeBuilder<Yazar> builder)
        {
            builder.Property(x=>x.YazarAdi).HasColumnType("nvarchar").HasMaxLength(30).IsRequired();
            builder.HasData(
                new Yazar { YazarID = 1, YazarAdi = "Elif Şafak" },
    new Yazar { YazarID = 2, YazarAdi = "Orhan Pamuk" },
    new Yazar { YazarID = 3, YazarAdi = "Ahmet Ümit" },
    new Yazar { YazarID = 4, YazarAdi = "Kemal Tahir" },
    new Yazar { YazarID = 5, YazarAdi = "Hakan Günday" },
    new Yazar { YazarID = 6, YazarAdi = "Aslı Erdoğan" },
    new Yazar { YazarID = 7, YazarAdi = "Zülfü Livaneli" },
    new Yazar { YazarID = 8, YazarAdi = "Sabahattin Ali" },
    new Yazar { YazarID = 9, YazarAdi = "İskender Pala" },
    new Yazar { YazarID = 10, YazarAdi = "Pınar Kür" }
                );
        }
    }
}
