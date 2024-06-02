using Microsoft.AspNetCore.Mvc;
using ShizUslugi.Models;
using ShizUslugi.VIewModels;

namespace ShizUslugi.Controllers
{
	public class PatientController : Controller
	{
		public readonly ApplicationContext _context;
		public PatientController(ApplicationContext context)
		{
			_context = context;
		}
		public IActionResult Index()
		{
			AllPatientViewModel data = new AllPatientViewModel();
			data.Schedules = _context.schedule.ToList();
			data.Doctors = _context.doctor.ToList();
			data.patient = StaticStuff.patient;
			return View(data);
		}
	}
}
