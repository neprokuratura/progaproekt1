using Microsoft.AspNetCore.Mvc;
using ShizUslugi.Models;
using ShizUslugi.ViewModels;
namespace ShizUslugi.Controllers
{
	public class DoctorController : Controller
	{
		private readonly ApplicationContext _context;
		public DoctorController(ApplicationContext context)
		{
			_context = context;
		}
		public IActionResult Index()
		{
			AllDoctorViewModel model = new AllDoctorViewModel();
			model.doctor = StaticStuff.doctor;
			return View(model);
		}
	}
}
