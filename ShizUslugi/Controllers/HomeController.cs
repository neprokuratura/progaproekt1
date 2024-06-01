using Microsoft.AspNetCore.Mvc;
using ShizUslugi.Models;
using System.Diagnostics;

namespace ShizUslugi.Controllers
{
	public class HomeController : Controller
	{
		private readonly ApplicationContext _context;

		//private readonly ILogger<HomeController> _logger;

		public HomeController( ApplicationContext context)
		{
			//_logger = logger;
			_context = context;
		}

		public IActionResult Index()
		{
			return View();
		}

		public IActionResult Privacy()
		{
			return View();
		}

		public IActionResult Test(string account, string password)
		{
			List<Account> accounts = _context.account.Where<Account>(a => a.login == account).ToList();
			if(accounts.Count != 0)
			{
				if(password == accounts[0].password)
				{

				}
			}
			else
			{

			}
			Console.WriteLine("jepa");
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
