using Microsoft.AspNetCore.Authorization; // oturum açmayı gereklı kılan kütüphane
using Microsoft.AspNetCore.Mvc;

namespace P013WebSite.Areas.Admin.Controllers
{
	public class MainController : Controller
	{
		[Area("Admin"), Authorize] // bir controller a authorize attribute ü uygularsak controller içerisindeki bütün action lara erişimi engellemiş oluruz.
		public IActionResult Index()
		{
			return View();
		}
	}
}
