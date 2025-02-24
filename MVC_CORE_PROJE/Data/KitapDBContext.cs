using Microsoft.AspNetCore.Identity;
using System.Reflection;
using MVC_CORE_PROJE.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MVC_CORE_PROJE.Data
{
    public class KitapDBContext : IdentityDbContext<Kullanici, KullaniciRol, int>
    {
        private readonly IConfiguration _config;
        public KitapDBContext(DbContextOptions options, IConfiguration configuration) : base(options)
        {
            _config = configuration;
        }

        protected KitapDBContext()
        {
        }

        public DbSet<Kitap> Kitaplar { get; set; }
        public DbSet<Yazar> Yazarlar { get; set; }
        public DbSet<YayinEvi> YayinEvleri { get; set; }
        public DbSet<Kategori> Kategoriler { get; set; }
        public DbSet<Kitap_Yazar> Kitap_Yazarlar { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(_config.GetConnectionString("ConnStr"));
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            builder.Entity<IdentityUserRole<int>>().HasData(new IdentityUserRole<int> { UserId = 1, RoleId = 1 });
            builder.Entity<IdentityUserRole<int>>().HasData(new IdentityUserRole<int> { UserId = 2, RoleId = 2 });
            builder.Entity<IdentityUserRole<int>>().HasData(new IdentityUserRole<int> { UserId = 3, RoleId = 2 });
            builder.Entity<IdentityUserRole<int>>().HasData(new IdentityUserRole<int> { UserId = 4, RoleId = 2 });
            base.OnModelCreating(builder);
        }
    }
}
