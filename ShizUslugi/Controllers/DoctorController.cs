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
		[HttpGet]
		public IActionResult MyPatients()
		{
			AllDoctorViewModel model = new AllDoctorViewModel();
			List<int> pid = new List<int>();
			List<Patient> p	= new List<Patient>();
			int i = 0;
			foreach (var v in _context.doctor_and_patient.Where(a => a.doctorid == StaticStuff.doctor.id))
			{
				pid.Add(v.patientid);
				p.Add(_context.patient.Where<Patient>(b => b.id == v.patientid).ToList()[i]);
				i++;
			}
			model.patients = p;
			return View(model);

		}
	}
}
