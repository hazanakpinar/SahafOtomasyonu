using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MVC_CORE_PROJE.Models;


namespace IdentityMVCManuel.Configurations
{
    public class Kullanici_CFG : IEntityTypeConfiguration<Kullanici>
    {
        public void Configure(EntityTypeBuilder<Kullanici> builder)
        {
            Kullanici admin = new Kullanici
            {
                Id = 1,
                UserName = "Admin",
                NormalizedUserName = "ADMIN",
                Email = "admin@admin.com",
                NormalizedEmail = "ADMIN@ADMIN.COM",
                Isim = "Admin",
                Soyisim = "Admin",
                Adres = "Kadıköy",
                Cinsiyet = MVC_CORE_PROJE.Enums.Cinsiyet.Kadın,
                IseGirisTarihi = DateTime.Now,

                ConcurrencyStamp = Guid.NewGuid().ToString(),
                SecurityStamp = Guid.NewGuid().ToString(),
                EmailConfirmed = false,
            };
            //Password
            PasswordHasher<Kullanici> hasher = new PasswordHasher<Kullanici>();
            admin.PasswordHash = hasher.HashPassword(admin, "Admin123.");
            builder.HasData(admin);

            Kullanici ronan = new Kullanici
            {
                Id = 2,
                UserName = "Ronan",
                NormalizedUserName = "RONAN",
                Email = "enim.suspendisse@google.couk",
                NormalizedEmail = "ENIM.SUSPENDISSE@GOOGLE.COUK",
                Isim = "Ronan",
                Soyisim = "Coleman",
                Adres = "Ireland",
                PhoneNumber = "12339743758",
                Cinsiyet = MVC_CORE_PROJE.Enums.Cinsiyet.Erkek,
                IseGirisTarihi = new DateTime(2024, 10, 26),

                ConcurrencyStamp = Guid.NewGuid().ToString(),
                SecurityStamp = Guid.NewGuid().ToString(),
                EmailConfirmed = false,
            };
            ronan.PasswordHash = hasher.HashPassword(ronan, "Ronan123.");
            builder.HasData(ronan);

            Kullanici herrod = new Kullanici
            {
                Id = 3,
                UserName = "Herrod",
                NormalizedUserName = "HERROD",
                Email = "vel.sapien@aol.ca",
                NormalizedEmail = "VEL.SAPIEN@AOL.CA",
                Isim = "Herrod",
                Soyisim = "Justice",
                Adres = "Colombia",
                PhoneNumber = "14688768054",
                Cinsiyet = MVC_CORE_PROJE.Enums.Cinsiyet.Erkek,
                IseGirisTarihi =new DateTime(2024, 10, 27),

                ConcurrencyStamp = Guid.NewGuid().ToString(),
                SecurityStamp = Guid.NewGuid().ToString(),
                EmailConfirmed = false,
            };
            herrod.PasswordHash = hasher.HashPassword(herrod, "Herrod123.");
            builder.HasData(herrod);

            Kullanici isadora = new Kullanici
            {
                Id = 4,
                UserName = "Isadora",
                NormalizedUserName = "ISADORA",
                Email = "donec@outlook.net",
                NormalizedEmail = "DONEC@OUTLOOK.NET",
                Isim = "Isadora",
                Soyisim = "Woodard",
                Adres = "Costa Rica",
                PhoneNumber = "1385487214",
                Cinsiyet = MVC_CORE_PROJE.Enums.Cinsiyet.Kadın,
                IseGirisTarihi = new DateTime(2024, 10, 28),

                ConcurrencyStamp = Guid.NewGuid().ToString(),
                SecurityStamp = Guid.NewGuid().ToString(),
                EmailConfirmed = false,
            };
            isadora.PasswordHash = hasher.HashPassword(isadora, "Isadora123.");
            builder.HasData(isadora);

            // softdelete için
            builder.Property(x => x.AktifMi).HasDefaultValue(true);

            builder.Property(x=>x.Isim).HasColumnType("nvarchar").HasMaxLength(50);
            builder.Property(x=>x.Soyisim).HasColumnType("nvarchar").HasMaxLength(50);
            builder.Property(x=>x.IseGirisTarihi).HasColumnType("date");
        }
    }
}
