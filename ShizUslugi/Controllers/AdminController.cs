using Microsoft.AspNetCore.Mvc;

namespace ShizUslugi.Controllers
{
	public class AdminController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
