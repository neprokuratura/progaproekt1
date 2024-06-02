using Microsoft.AspNetCore.Mvc;
using ShizUslugi.Models;
using ShizUslugi.ViewModels;
using System.Diagnostics;
using System.Reflection.Metadata.Ecma335;

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
		[HttpGet]
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
					if (accounts[0].status)
					{
						StaticStuff.doctor = _context.doctor.Where<Doctor>(d => d.accountid == accounts[0].id).ToList()[0];
						return RedirectToAction("Index", "Doctor");
					}
					else
					{
						StaticStuff.patient = _context.patient.Where<Patient>(p => p.accountid == accounts[0].id).ToList()[0];
						return  RedirectToAction("Index", "Patient");
					}
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
		[HttpGet]
		public IActionResult Register()
		{
			var response = new RegisterViewModel();
			return View(response);
		}
		[HttpPost]
		public IActionResult Register(RegisterViewModel A)
		{
			List<Account> accounts = _context.account.Where<Account>(a => a.login == A.account.login).ToList();
			if(accounts.Count != 0)
			{
				A.IsUserExisting = true;
				return View(A);
			}
			else
			{
				_context.account.Add(new Account { login = A.account.login, password = A.account.password, status = true });
				_context.SaveChanges();
				Account account = _context.account.Where<Account>(a => a.login == A.account.login).ToList()[0];
				_context.doctor.Add(new Doctor { accountid = account.id,  cabinetnumber = A.cabinetnumber, name = A.name,
				surname = A.surname, thirdname = A.thirdname, phonenumber = A.phonenumber, specialization = A.specialization});
				_context.SaveChanges();
				return RedirectToAction("Index");
			}
        }
		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
