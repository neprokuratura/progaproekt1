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
					StaticStuff.status = accounts[0].status;
					if (accounts[0].id == StaticStuff.adminid)
					{
						StaticStuff.doctor = _context.doctor.Where(d => d.accountid == accounts[0].id).ToList()[0];
						return RedirectToAction("Index", "Admin");
					}
					if (accounts[0].status)
					{
						StaticStuff.doctor = _context.doctor.Where(d => d.accountid == accounts[0].id).ToList()[0];
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
			response.IsFieldEmpty = false;
			return View(response);
		}
		[HttpPost]
		public IActionResult Register(RegisterViewModel A)
		{
			List<Account> accounts = _context.account.Where<Account>(a => a.login == A.account.login).ToList();
			if(accounts.Count != 0)
			{
				A.IsUserExisting = true;
				A.IsFieldEmpty = false;
				return View(A);
			}
			else
			{
				if (A.account.login == null)
				{
					A.FieldName = "Логин";
					return View(A);
				}
				else if (A.account.password == null)
				{
					A.FieldName = "Пароль";
					return View(A);
				}
				else if (A.name == null)
				{
					A.FieldName = "Имя";
					return View(A);
				}
				else if (A.surname == null)
				{
					A.FieldName = "Фамилия";
					return View(A);
				}
				else if (A.specialization == null)
				{
					A.FieldName = "Специализация";
					return View(A);
				}
				else if (A.phonenumber == null)
				{
					A.FieldName = "Телефон";
					return View(A);
				}
				else
				{
					A.IsFieldEmpty = false;
					A.IsFieldOverfilled = true;
					if (A.account.login.Length > 20)
					{
						A.FieldName = "Логин";
					}
					else if (A.account.password.Length > 20)
					{
						A.FieldName = "Пароль";
					}
					else if (A.name.Length > 20)
					{
						A.FieldName = "Имя";
					}
					else if (A.surname.Length > 20)
					{
						A.FieldName = "Фамилия";
					}
					else if (A.thirdname == null ? false: A.thirdname.Length > 20)
					{
							A.FieldName = "Отчество";
				    }
					else if (A.specialization.Length > 50)
					{
						A.FieldName = "Специализация";
					}
					else if (A.phonenumber.Length > 12)
					{
						A.FieldName = "Телефон";
					}
					else
					{
						A.IsFieldOverfilled = false;
						_context.account.Add(new Account { login = A.account.login, password = A.account.password, status = true });
						_context.SaveChanges();
						Account account = _context.account.Where<Account>(a => a.login == A.account.login).ToList()[0];
						_context.doctor.Add(new Doctor
						{
							accountid = account.id,
							cabinetnumber = A.cabinetnumber,
							name = A.name,
							surname = A.surname,
							thirdname = A.thirdname,
							phonenumber = A.phonenumber,
							specialization = A.specialization
						});
						_context.SaveChanges();
						return RedirectToAction("Index");
					}
				}
				return View(A);
			}
        }
		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
