using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MVC_CORE_PROJE.Data;
using MVC_CORE_PROJE.Models;
using MVC_CORE_PROJE.Models.DTOs;
namespace ProjeOdevi.Services
{
    public class KitapRepository : BaseRepository<Kitap>
    {
        private readonly IMapper _mapper;
        public KitapRepository(KitapDBContext context, IMapper mapper) : base(context)
        {
            _context = context;
            _mapper = mapper;
        }
        // Tüm Kitapların Listesi 
        public IEnumerable<dynamic> TumKitaplariListele()
        {
            return _context.Kitaplar
                 .Include(b => b.Kategori)
                 .Include(b => b.YayinEvi)
                 .Include(b => b.Kitap_Yazarlar)
                 .ThenInclude(b => b.Yazar)
                 .Select(b => new
                 {
                     KitapID = b.KitapID,
                     KitapAdi = b.KitapAdi,
                     Fiyat = b.Fiyat,
                     KapakResmi = b.KapakResmi,
                     Kategori = b.Kategori.KategoriAdi,
                     Yazar = string.Join(", ", b.Kitap_Yazarlar.Select(ba => ba.Yazar.YazarAdi)),
                     YayinEvi = b.YayinEvi.YayinEviAdi,
                     Stok = b.Stok
                 })
                 .ToList();
        }

        // Kitap ekleme yazar ile
        public void Ekle(Kitap_DTO kitapDto)
        {
            var kitap = new Kitap();
            _mapper.Map(kitapDto, kitap);

            table.Add(kitap);
            _context.SaveChanges();

            foreach (var item in kitapDto.YazarIDleri)
            {
                Kitap_Yazar kitap_Yazar = new Kitap_Yazar();
                kitap_Yazar.KitapID = kitap.KitapID;
                kitap_Yazar.YazarID = item;
                _context.Kitap_Yazarlar.Add(kitap_Yazar);
                _context.SaveChanges();
            }
        }

        // Bir kategoriye ait tüm kitapların listesi
        public IEnumerable<object> KategoriyeGoreKitaplariListele(int KategoriId)
        {
            return _context.Kitaplar
                .Where(b => b.KategoriID == KategoriId)
                .Include(b => b.YayinEvi)
                .Include(b => b.Kategori)
                .Include(b => b.Kitap_Yazarlar)
                .ThenInclude(b => b.Yazar)
                 .Select(b => new
                 {
                     KitapID = b.KitapID,
                     KitapAdi = b.KitapAdi,
                     Fiyat = b.Fiyat,
                     KapakResmi = b.KapakResmi,
                     Kategori = b.Kategori.KategoriAdi,
                     Yazar = string.Join(", ", b.Kitap_Yazarlar.Select(ba => ba.Yazar.YazarAdi)),
                     YayinEvi = b.YayinEvi.YayinEviAdi,
                     Stok = b.Stok
                 })
                 .ToList();
        }

        // Bir yazara ait tüm kitaplarının listesi
        public IEnumerable<object> YazaraGoreKitaplariListele(int yazarId)
        {
            return _context.Kitaplar
                .Where(b => b.Kitap_Yazarlar.Any(ba => ba.YazarID == yazarId))
                .Include(b => b.Kitap_Yazarlar)
                .Include(b => b.Kategori)
                .Include(b => b.YayinEvi)
                 .Select(b => new
                 {
                     KitapID = b.KitapID,
                     KitapAdi = b.KitapAdi,
                     Fiyat = b.Fiyat,
                     KapakResmi = b.KapakResmi,
                     Kategori = b.Kategori.KategoriAdi,
                     Yazar = string.Join(", ", b.Kitap_Yazarlar.Select(ba => ba.Yazar.YazarAdi)),
                     YayinEvi = b.YayinEvi.YayinEviAdi,
                     Stok = b.Stok
                 })
                 .ToList();
        }

        // Bir yayınevine ait tüm kitaplarının listesi
        public IEnumerable<object> YayinEvineGoreKitaplariListele(int YayinEviId)
        {
            return _context.Kitaplar
                .Where(b => b.YayinEviID == YayinEviId)
                .Include(b => b.Kategori)
                .Include(b => b.YayinEvi)
                .Include(b => b.Kitap_Yazarlar)
                .ThenInclude(b => b.Yazar)
                 .Select(b => new
                 {
                     KitapID = b.KitapID,
                     KitapAdi = b.KitapAdi,
                     Fiyat = b.Fiyat,
                     KapakResmi = b.KapakResmi,
                     Kategori = b.Kategori.KategoriAdi,
                     Yazar = string.Join(", ", b.Kitap_Yazarlar.Select(ba => ba.Yazar.YazarAdi)),
                     YayinEvi = b.YayinEvi.YayinEviAdi,
                     Stok = b.Stok
                 })
                 .ToList();
        }

        // Sisteme en son girilen 10 kitabın listelemesi
        public IEnumerable<object> SonOnKitaplariListele()
        {
            return _context.Kitaplar
                .OrderByDescending(b => b.KitapID)
                .Take(10)
                .Include(b => b.Kategori)
                .Include(b => b.YayinEvi)
                .Include(b => b.Kitap_Yazarlar)
                .ThenInclude(b => b.Yazar)
                 .Select(b => new
                 {
                     KitapID = b.KitapID,
                     KitapAdi = b.KitapAdi,
                     Fiyat = b.Fiyat,
                     KapakResmi = b.KapakResmi,
                     Kategori = b.Kategori.KategoriAdi,
                     Yazar = string.Join(", ", b.Kitap_Yazarlar.Select(ba => ba.Yazar.YazarAdi)),
                     YayinEvi = b.YayinEvi.YayinEviAdi,
                     Stok = b.Stok
                 })
                 .ToList();
        }

        // Belirli fiyat aralığında olan kitapların listesi
        public IEnumerable<object> FiyatAraliğineGoreListele(decimal minFiyat, decimal maxFiyat)
        {
            return _context.Kitaplar
                .Where(b => b.Fiyat >= minFiyat && b.Fiyat <= maxFiyat)
                .Include(b => b.Kategori)
                .Include(b => b.YayinEvi)
                .Include(b => b.Kitap_Yazarlar)
                .ThenInclude(b => b.Yazar)
                 .Select(b => new
                 {
                     KitapID = b.KitapID,
                     KitapAdi = b.KitapAdi,
                     Fiyat = b.Fiyat,
                     KapakResmi = b.KapakResmi,
                     Kategori = b.Kategori.KategoriAdi,
                     Yazar = string.Join(", ", b.Kitap_Yazarlar.Select(ba => ba.Yazar.YazarAdi)),
                     YayinEvi = b.YayinEvi.YayinEviAdi,
                     Stok = b.Stok
                 })
                 .ToList();
        }

        public void UpdateBook(Kitap updatedBook, IFormFile ResimDosyasi, List<int> yeniYazarID)
        {
            var existingBook = _context.Kitaplar
                .Include(k => k.Kitap_Yazarlar)
                .FirstOrDefault(k => k.KitapID == updatedBook.KitapID);

            if (existingBook != null)
            {
                existingBook.KitapAdi = updatedBook.KitapAdi;
                existingBook.Fiyat = updatedBook.Fiyat;
                existingBook.KategoriID = updatedBook.KategoriID;
                existingBook.YayinEviID = updatedBook.YayinEviID;
                existingBook.Stok = updatedBook.Stok;

                if (ResimDosyasi != null)
                {
                    string path = "wwwroot/resimler/" + ResimDosyasi.FileName;
                    FileStream fs = new FileStream(path, FileMode.Create);
                    ResimDosyasi.CopyTo(fs);
                    fs.Close();
                    existingBook.KapakResmi = "/resimler/" +ResimDosyasi.FileName;
                }
                else
                {
                    existingBook.KapakResmi = "";
                }

                existingBook.Kitap_Yazarlar.Clear();

                if (existingBook.Kitap_Yazarlar == null)
                {
                    existingBook.Kitap_Yazarlar = new List<Kitap_Yazar>();
                }

                // Yeni yazarları ekle
                foreach (var yazarId in yeniYazarID)
                {
                    var kitapYazar = new Kitap_Yazar
                    {
                        KitapID = existingBook.KitapID,
                        YazarID = yazarId
                    };
                    existingBook.Kitap_Yazarlar.Add(kitapYazar);
                }

                _context.SaveChanges();
            }
            else
            {
                throw new Exception("Kitap bulunamadı.");
            }
        }
    }
}
