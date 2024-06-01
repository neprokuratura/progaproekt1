using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
	public class SomeController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
