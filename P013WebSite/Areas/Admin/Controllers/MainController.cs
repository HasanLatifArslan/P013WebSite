using Microsoft.AspNetCore.Authorization; // oturum açmayı gerekli kılan kütüphane
using Microsoft.AspNetCore.Mvc;

namespace P013WebSite.Areas.Admin.Controllers
{
	public class MainController : Controller
	{
		[Area("Admin"), Authorize] // Bir controller a authorize ü uygularksak controller içerisindeki büyün actionlara erişimi engellemiş oluyoruz sadece oturum açan kullanıcılar ekranı görebilir
		public IActionResult Index()
		{
			return View();
		}
	}
}
