using Microsoft.AspNetCore.Mvc;

namespace P013WebSite.Areas.Admin.Controllers
{
	public class MainController : Controller
	{
		[Area("Admin")]
		public IActionResult Index()
		{
			return View();
		}
	}
}
