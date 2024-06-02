using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
			List<Patient> p	= new List<Patient>();
			List<Doctor_Patient_id> a = _context.doctor_and_patient.Where(a => a.doctorid == StaticStuff.doctor.id).ToList();
			foreach (var v in a)
			{
				p.Add(_context.patient.Where<Patient>(b => b.id == v.patientid).ToList()[0]);
			}
			model.chambers = _context.chamber.ToList();
			model.patients = p;
			return View(model);
		}
	}
}
