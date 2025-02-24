using Microsoft.EntityFrameworkCore;
using MVC_CORE_PROJE.Data;
using MVC_CORE_PROJE.Models;
using Microsoft.AspNetCore.Identity;
using ProjeOdevi.Services;
using AutoMapper;
using System.Reflection;
using MVC_CORE_PROJE.UI_Mapper;

var builder = WebApplication.CreateBuilder(args);
//var connectionString = builder.Configuration.GetConnectionString("KitapDBContext") ?? throw new InvalidOperationException("Connection string 'KitapDBContextConnection' not found.");

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<KitapDBContext>(x => x.UseSqlServer());

//builder.Services.AddDefaultIdentity<Kullanici>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<KitapDBContext>();

builder.Services.AddIdentity<Kullanici, KullaniciRol>(x => x.SignIn.RequireConfirmedEmail = false)
                .AddRoles<KullaniciRol>()
                .AddEntityFrameworkStores<KitapDBContext>();
builder.Services.AddScoped<KitapRepository>();
builder.Services.AddScoped<BaseRepository<Kullanici>>();

// autoMapper
builder.Services.AddAutoMapper(typeof(Mapper), typeof(UI_Mapper));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();


app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );
});

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Giris}/{action=GirisYap}/{id?}");

app.Run();
