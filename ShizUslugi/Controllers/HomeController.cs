using Microsoft.AspNetCore.Mvc;
using ShizUslugi.Models;
using ShizUslugi.ViewModels;
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
			var response = new AccountViewModel();
			return View(response);
		}

		public IActionResult Privacy()
		{
			return View();
		}
		[HttpPost]
		public IActionResult Index(AccountViewModel A)
		{
			List<Account> accounts = _context.account.Where<Account>(a => a.login == A.login).ToList();
			if(accounts.Count != 0)
			{
				if(A.password == accounts[0].password)
				{

				}
				else
				{
					A.IsPasswordCorrect = false;
				}
			}
			else
			{
				A.IsUserExisting = false;
			}
			return View(A);
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
