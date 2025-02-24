using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVC_CORE_PROJE.Areas.CalisanPanel.Models.ViewModels;
using MVC_CORE_PROJE.Data;
using MVC_CORE_PROJE.Models;
using MVC_CORE_PROJE.Models.DTOs;
using ProjeOdevi.Services;
using System.Drawing;

namespace MVC_CORE_PROJE.Areas.CalisanPanel.Controllers
{
    [Area("CalisanPanel")]
    [Authorize(Roles = "Calisan,Admin")]

    public class CalisanController : Controller
    {
        private readonly KitapRepository _kitapRepository;
        private readonly KitapDBContext _context;
        private readonly IMapper _mapper;
        public CalisanController(KitapRepository kitapRepository, KitapDBContext context, IMapper mapper)
        {
            _kitapRepository = kitapRepository;
            _context = context;
            _mapper = mapper;
        }

        public IActionResult KitapListele()
        {
            var tumKitaplar = _kitapRepository.TumKitaplariListele().ToList();
            return View(tumKitaplar);
        }
        public IActionResult KitapEkle()
        {
            var yazarListesi = new SelectList(_context.Yazarlar.ToList(), "YazarID", "YazarAdi");
            var kategoriListesi = new SelectList(_context.Kategoriler.ToList(), "KategoriID", "KategoriAdi");
            var yayinEviListesi = new SelectList(_context.YayinEvleri.ToList(), "YayinEviID", "YayinEviAdi");
            ViewBag.Kategoriler = kategoriListesi;
            ViewBag.YayinEvleri = yayinEviListesi;
            ViewBag.Yazarlar = yazarListesi;
            return View();
        }
        [HttpPost]
        public IActionResult KitapEkle(KitapEkle_VM kitap, IFormFile ResimDosyasi, int[] yazarIDleri)
        {
            if (ModelState.IsValid && yazarIDleri.Length > 0)
            {
                Kitap_DTO yeniKitap = new Kitap_DTO();
                _mapper.Map(kitap, yeniKitap);

                if (ResimDosyasi != null)
                {
                    string path = "wwwroot/resimler/" + ResimDosyasi.FileName;
                    FileStream fs = new FileStream(path, FileMode.Create);
                    ResimDosyasi.CopyTo(fs);
                    fs.Close();
                    yeniKitap.KapakResmi = "/resimler/" + ResimDosyasi.FileName;
                }
                else
                {
                    yeniKitap.KapakResmi = "";
                }
                yeniKitap.YazarIDleri = yazarIDleri;
                _kitapRepository.Ekle(yeniKitap);
                return RedirectToAction("KitapListele");
            }

            ViewBag.Kategoriler = new SelectList(_context.Kategoriler.ToList(), "KategoriID", "KategoriAdi");
            ViewBag.YayinEvleri = new SelectList(_context.YayinEvleri.ToList(), "YayinEviID", "YayinEviAdi");
            ViewBag.Yazarlar = new SelectList(_context.Yazarlar.ToList(), "YazarID", "YazarAdi");

            return View(kitap);
        }

        public IActionResult KitapGuncelle(int id)
        {
            var yazarlar = _context.Yazarlar
                   .Select(y => new SelectListItem
                   {
                       Value = y.YazarID.ToString(),
                       Text = y.YazarAdi
                   }).ToList(); var kategoriListesi = new SelectList(_context.Kategoriler.ToList(), "KategoriID", "KategoriAdi");

            var yayinEviListesi = new SelectList(_context.YayinEvleri.ToList(), "YayinEviID", "YayinEviAdi");
            ViewBag.Kategoriler = kategoriListesi;
            ViewBag.YayinEvleri = yayinEviListesi;
            ViewBag.Yazarlar = yazarlar ?? new List<SelectListItem>();


            var kitap = _context.Kitaplar
                 .Include(b => b.Kategori)
                 .Include(b => b.YayinEvi)
                 .Include(b => b.Kitap_Yazarlar).ThenInclude(x => x.Yazar).FirstOrDefault(x => x.KitapID == id);

            var selectedAuthorIds = kitap.Kitap_Yazarlar.Select(ky => ky.YazarID).ToList();
            ViewBag.SelectedAuthorIds = selectedAuthorIds;

            return View(kitap);
        }

        [HttpPost]
        public IActionResult KitapGuncelle(Kitap kitap, IFormFile ResimDosyasi, List<int> yazarIDleri)
        {
            if (kitap != null)
            {
                _kitapRepository.UpdateBook(kitap, ResimDosyasi, yazarIDleri);
            }
            return RedirectToAction("KitapListele");
        }
        [HttpGet]
        public IActionResult KitapSil(int id)
        {
            var kitap = _context.Kitaplar
                 .Include(b => b.Kategori)
                 .Include(b => b.YayinEvi)
                 .Include(b => b.Kitap_Yazarlar).ThenInclude(x => x.Yazar).FirstOrDefault(x => x.KitapID == id);
            ViewBag.Kategoriler = kitap.Kategori.KategoriAdi;
            ViewBag.YayinEvleri = kitap.YayinEvi.YayinEviAdi;
            ViewBag.Yazarlar = kitap.Kitap_Yazarlar;
            return View(kitap);

        }
        [HttpPost]
        public IActionResult KitapSil(Kitap kitap)
        {
            var silinenKitap = _kitapRepository.Ara(kitap.KitapID);
            if (silinenKitap != null)
            {
                _kitapRepository.Sil(silinenKitap.KitapID);
            }
            return RedirectToAction("KitapListele");
        }

        public IActionResult KitapDetay(int id)
        {
            var kitap = _context.Kitaplar
                 .Include(b => b.Kategori)
                 .Include(b => b.YayinEvi)
                 .Include(b => b.Kitap_Yazarlar).ThenInclude(x => x.Yazar).FirstOrDefault(x => x.KitapID == id);

            return View(kitap);
        }

    }

}