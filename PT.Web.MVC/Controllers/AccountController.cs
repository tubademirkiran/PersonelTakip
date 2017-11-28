using Microsoft.AspNet.Identity;
using PT.BLL.AccountRepository;
using PT.BLL.Settings;
using PT.Entity.IdentityModel;
using PT.Entity.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace PT.Web.MVC.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Register() //kayıt işlemi
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken] //Güvenlik testleri için
        public async Task<ActionResult> Register(RegisterViewModel model) //asenkron kullanılacaksa asycn yazılır
        {
            //kayıt olmadan önce kontrol ediliyor
            if (!ModelState.IsValid)
                return View(model);
            var userManager = MemberShipTools.NewUserManager();
            var checkUser = userManager.FindByName(model.Username);
            if (checkUser != null)
            {
                ModelState.AddModelError(string.Empty, "Bu kullanıcı zaten kayıtlı!");
                return View(model);
            }
            //register işlemi yapılır
            var activationCode = Guid.NewGuid().ToString(); //aktivasyon kodu üretilir
            ApplicationUser user = new ApplicationUser() //kullanıcı oluşturduk
            {
                Name = model.Name,
                Surname = model.Surname,
                Email = model.Email,
                UserName = model.Username,
                ActivationCode = activationCode
            };
            var response = userManager.Create(user, model.Password); //arka planda şifreler koyar
            if (response.Succeeded)
            {
                string siteUrl = Request.Url.Scheme + Uri.SchemeDelimiter + Request.Url.Host + (Request.Url.IsDefaultPort ? "" : ":" + Request.Url.Port);
                if (userManager.Users.Count()==1)
                {
                    userManager.AddToRole(user.Id, "Admin");
                    await SiteSettings.SendMail(new MailModel
                    {
                        To=user.Email,
                        Subject="Hoşgeldin Sahip",
                        Message="Sitemizi yöneteceğin için çok mutluyuz:)"
                    });
                }
                else
                {
                    userManager.AddToRole(user.Id, "Passive");
                    await SiteSettings.SendMail(new MailModel
                    {
                        To = user.Email,
                        Subject = "Personel Yönetimi-Aktivasyon",
                        Message = $"Merhaba {user.UserName}, </br> Sisteme başarı ile kayıt oldunuz. <br/> Hesabınızı aktifleştirmek için <a href='{siteUrl}/Account/Activation?code={activationCode}'>Aktivasyon Kodu</a>",//her zaman aynı local gelmeyebilir
                        
                    });
                }
                return RedirectToAction("Login", "Account");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Kayıt işleminde bir hata oluştu.");
                return View();
            }
           
        }

    }
}
