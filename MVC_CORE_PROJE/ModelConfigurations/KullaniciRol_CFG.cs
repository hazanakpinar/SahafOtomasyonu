using IdentityMVCManuel.Models;
using Microsoft.EntityFrameworkCore;
using MVC_CORE_PROJE.Models;

namespace IdentityMVCManuel.Configurations
{
    public class KullaniciRol_CFG : IEntityTypeConfiguration<KullaniciRol>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<KullaniciRol> builder)
        {
            builder.HasData(new KullaniciRol { Id = 1, Name = "Admin", NormalizedName = "ADMIN", ConcurrencyStamp = Guid.NewGuid().ToString() });  
            builder.HasData(new KullaniciRol { Id = 2, Name = "Calisan", NormalizedName = "CALISAN", ConcurrencyStamp = Guid.NewGuid().ToString() });
        }
    }
}
