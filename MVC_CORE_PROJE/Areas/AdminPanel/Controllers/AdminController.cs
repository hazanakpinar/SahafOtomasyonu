using IdentityMVCManuel.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVC_CORE_PROJE.Data;
using MVC_CORE_PROJE.Enums;
using MVC_CORE_PROJE.Models;
using ProjeOdevi.Services;

namespace MVC_CORE_PROJE.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly KitapDBContext _context;
        private readonly BaseRepository<Kullanici> _baseRepository;
        private readonly UserManager<Kullanici> _kullaniciManager;
        private readonly KitapRepository _kitapRepository;

        public AdminController(KitapDBContext context, BaseRepository<Kullanici> baseRepository, UserManager<Kullanici> kullaniciManager, KitapRepository kitapRepository)
        {
            _context = context;
            _baseRepository = baseRepository;
            _kullaniciManager = kullaniciManager;
            _kitapRepository = kitapRepository;
        }

        public IActionResult Index()
        {
            var yazarListesi = new SelectList(_context.Yazarlar.ToList(), "YazarID", "YazarAdi");
            var kategoriListesi = new SelectList(_context.Kategoriler.ToList(), "KategoriID", "KategoriAdi");
            var yayinEviListesi = new SelectList(_context.YayinEvleri.ToList(), "YayinEviID", "YayinEviAdi");
            ViewBag.Kategoriler = kategoriListesi;
            ViewBag.YayinEvleri = yayinEviListesi;
            ViewBag.Yazarlar = yazarListesi;
            return View();
        }
        public IActionResult CalisanListele()
        {
            var kullanicilar = _baseRepository.Listele().Where(x => _kullaniciManager.IsInRoleAsync(x, "Calisan").Result).ToList();
            return View(kullanicilar);
        }
        public IActionResult CalisanEkle()
        {
            var cinsiyet = new SelectList(Enum.GetNames(typeof(Cinsiyet)), "Cinsiyet");
            ViewBag.Cinsiyetler = cinsiyet;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CalisanEkle(CalisanKayit_VM calisan)
        {
            if (ModelState.IsValid)
            {
                Kullanici yeniKullanici = new Kullanici();
                yeniKullanici.Isim = calisan.Isim;
                yeniKullanici.Soyisim = calisan.Soyisim;
                yeniKullanici.Adres = calisan.Adres;
                yeniKullanici.Cinsiyet = calisan.Cinsiyet;
                yeniKullanici.PhoneNumber = calisan.TelefonNumarasi;
                yeniKullanici.IseGirisTarihi = calisan.IseGirisTarihi;
                yeniKullanici.Email = calisan.Email;
                yeniKullanici.NormalizedEmail = calisan.Email.ToUpper();
                yeniKullanici.UserName = calisan.Email;
                yeniKullanici.NormalizedUserName = calisan.Email.ToUpper();
                yeniKullanici.AktifMi = true;

                var result = await _kullaniciManager.CreateAsync(yeniKullanici, calisan.Sifre);
                if (result.Succeeded)
                {
                    await _kullaniciManager.AddToRoleAsync(yeniKullanici, "Calisan");
                return RedirectToAction("CalisanListele", "Admin", new { area = "AdminPanel" });
                }
                var cinsiyet = new SelectList(Enum.GetNames(typeof(Cinsiyet)), "Cinsiyet");
                ViewBag.Cinsiyetler = cinsiyet;
                return View(calisan);
            }
            var cinsiyet2 = new SelectList(Enum.GetNames(typeof(Cinsiyet)), "Cinsiyet");
            ViewBag.Cinsiyetler = cinsiyet2;
            return View(calisan);
        }
        [HttpGet]
        public async Task<IActionResult> CalisanGuncelle(int id)
        {
            Kullanici guncellenecekKullanici = await _kullaniciManager.FindByIdAsync(id.ToString());
            var cinsiyet = new SelectList(Enum.GetNames(typeof(Cinsiyet)), "Cinsiyet");
            ViewBag.Cinsiyetler = cinsiyet;
            return View(guncellenecekKullanici);
        }

        [HttpPost]
        public async Task<IActionResult> CalisanGuncelle(Kullanici calisan,string yeniSifre)
        {
            if (ModelState.IsValid)
            {
                var user = await _kullaniciManager.FindByIdAsync(calisan.Id.ToString());
                if (user != null)
                {
                    user.Isim = calisan.Isim;
                    user.Soyisim = calisan.Soyisim;
                    user.Adres = calisan.Adres;
                    user.Cinsiyet = calisan.Cinsiyet;
                    user.IseGirisTarihi = calisan.IseGirisTarihi;
                    user.Email = calisan.Email;
                    user.AktifMi = calisan.AktifMi;
                    user.PhoneNumber = calisan.PhoneNumber;
                    PasswordHasher<Kullanici> hasher = new PasswordHasher<Kullanici>();
                    user.PasswordHash=hasher.HashPassword(user,yeniSifre);
                    

                    var result = await _kullaniciManager.UpdateAsync(user);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("CalisanListele", "Admin", new { area = "AdminPanel" });
                    }

                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }
            return View(calisan);
        }

        [HttpGet]
        public async Task<IActionResult> CalisanSil(int id)
        {
            Kullanici silinecekKullanici = await _kullaniciManager.FindByIdAsync(id.ToString());
            return View(silinecekKullanici);
        }

        [HttpPost]
        public async Task<IActionResult> CalisanSil(Kullanici kullanici)
        {
            var silinecekKullanici = await _kullaniciManager.FindByIdAsync(kullanici.Id.ToString());
            if (kullanici == null)
            {
                return NotFound();
            }
            silinecekKullanici.AktifMi = false;
            var result = await _context.SaveChangesAsync();
            return RedirectToAction("CalisanListele", "Admin", new { area = "AdminPanel" });
        }

        [HttpGet]
        public async Task<IActionResult> CalisanDetay(int id)
        {
            var kullanici = await _kullaniciManager.FindByIdAsync(id.ToString());
            return View(kullanici);
        }

        public IActionResult TumKitaplariListele()
        {
            _kitapRepository.TumKitaplariListele();
            return View();
        }
        [HttpPost]
        public IActionResult YayinEvineGoreKitaplariListele(int yayinEviID)
        {
            var yayinEviListesi = _kitapRepository.YayinEvineGoreKitaplariListele(yayinEviID);
            return View(yayinEviListesi);
        }
        [HttpPost]
        public IActionResult KategoriyeGoreKitaplariListele(int kategoriID)
        {
            var kategoriListesi = _kitapRepository.KategoriyeGoreKitaplariListele(kategoriID);
            return View(kategoriListesi);

        }
    }
}
