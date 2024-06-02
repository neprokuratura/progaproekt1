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
		public IActionResult MyDoctors()
		{
			AllPatientViewModel model = new AllPatientViewModel();
			List<Doctor_Patient_id> dp = _context.doctor_and_patient.Where(a => a.patientid == StaticStuff.patient.id).ToList();
			List<Doctor> doctors = new List<Doctor>();
			foreach(var v in dp)
			{
				doctors.Add(_context.doctor.Where(d => d.id == v.doctorid).ToList()[0]);
			}
			model.Doctors= doctors;
			return View(model);
		}
	}
}
