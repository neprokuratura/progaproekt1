using Microsoft.AspNetCore.Mvc;
using ShizUslugi.Models;
using ShizUslugi.ViewModels;

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
			data.Schedules = _context.schedule.Where(a => a.patientid == StaticStuff.patient.id).ToList();
			data.Doctors = _context.doctor.ToList();
			data.patient = StaticStuff.patient;
			return View(data);
		}
		[HttpGet]
		public IActionResult MySchedule()
		{
			AllPatientViewModel model = new AllPatientViewModel();
			model.Schedules = _context.schedule.Where(b => b.patientid == StaticStuff.patient.id).ToList();
			List<Doctor> p = new List<Doctor>();

			foreach (var v in model.Schedules)
			{
				p.Add(_context.doctor.Where<Doctor>(c => c.id == v.doctorid).ToList()[0]);
			}
			model.Doctors = p;
			return View(model);
		}
	}
}
