using IdentityMVCManuel.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVC_CORE_PROJE.Enums;
using System.Collections;
using MVC_CORE_PROJE.Models;

namespace MVC_CORE_PROJE.Controllers
{
    public class GirisController : Controller
    {
        private readonly UserManager<Kullanici> _userManager;
        private readonly SignInManager<Kullanici> _signInManager;

        public GirisController(UserManager<Kullanici> userManager, SignInManager<Kullanici> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IActionResult GirisYap()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> GirisYap(Giris_VM giris)
        {
            if (ModelState.IsValid)
            {
                var kullanici = await _userManager.FindByEmailAsync(giris.Email);
                if (kullanici != null)
                {
                    bool sifreDogrulama = await _userManager.CheckPasswordAsync(kullanici, giris.Sifre);
                    if (sifreDogrulama)
                    {
                        await _signInManager.SignInAsync(kullanici, false);
                        bool adminMi = await _userManager.IsInRoleAsync(kullanici, "Admin");
                        bool calisanMi = await _userManager.IsInRoleAsync(kullanici, "Calisan");
                        if (adminMi)
                        {
                             return RedirectToAction("Index", "Admin", new { area = "AdminPanel" });
                            //return Redirect("~/AdminPanel/Admin/Index");
                        }
                        else
                        {
                            return Redirect("~/CalisanPanel/Calisan/KitapListele");
                        }
                    }
                }
            }
            return View(giris);
        }
      public async Task<IActionResult> CikisYap()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("GirisYap");
        }    
    }
}
