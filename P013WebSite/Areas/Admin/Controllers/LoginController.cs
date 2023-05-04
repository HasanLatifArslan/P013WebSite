using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging.Abstractions;
using P013WebSite.Data;
using System.Security.Claims;

namespace P013WebSite.Areas.Admin.Controllers
{
    [Area("Admin"), Authorize]
    public class LoginController : Controller
    {
        private readonly DatabaseContext _context;
        public LoginController(DatabaseContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(string email, string password)
        {
            try
            {
                var kullanici = await _context.Users.FirstOrDefaultAsync(u => u.Email == email && u.Password == password && u.IsActive);
                if (kullanici == null)
                {
                    TempData["Mesaj"] = "Giriş Başarısız";
                }
                else
                {
                    var haklar = new List<Claim>() // claim = hak
                    {
                        new Claim(ClaimTypes.Email, kullanici.Email) // giriş için hak tanımladık
                    };
                    var kullaniciKimliği = new ClaimsIdentity(haklar, "Login"); // kullanıcıya kimlik tanımladık
                    ClaimsPrincipal claimsPrincipal = new(kullaniciKimliği);
                    await HttpContext.SignInAsync(claimsPrincipal);
                    if (kullanici.IsAdmin)
                    {
                        return Redirect("/Admin");
                    }
                    else
                    {
                        return Redirect("/Home");
                    }
                }
            }
            catch (Exception)
            {
                TempData["Mesaj"] = "Hata Oluştu!";

            }
            return View();
        }
        [Route("Logout")] // adres çubuğunda yaptığımız yönlendirmede login/logout yerine sadece logout a gidince çıkış yapsın
        public async Task<IActionResult> LogoutAsync()
        {
            await HttpContext.SignOutAsync();
            return Redirect("/Admin/Login");
        }
    }
}
