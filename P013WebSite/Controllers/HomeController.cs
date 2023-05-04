using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using P013WebSite.Data;
using P013WebSite.Models;
using System.Diagnostics;

namespace P013WebSite.Controllers
{
	public class HomeController : Controller
	{
		private readonly DatabaseContext _databaseContext;

		public HomeController(DatabaseContext databaseContext)
		{
			_databaseContext = databaseContext;
		}

		public async Task<IActionResult> IndexAsync()
		{
			var model = new HomePageViewModel()
			{
				Sliders = await _databaseContext.Slider.ToListAsync(),
				Products = await _databaseContext.Products.Where(p => p.IsActive && p.IsHome).ToListAsync()
			};

			return View(model);
		}

		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}