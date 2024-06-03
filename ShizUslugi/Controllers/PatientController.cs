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
			model.doctors= doctors;
			return View(model);
		}
		public IActionResult MyDiagnoses()
		{
            AllPatientViewModel model = new AllPatientViewModel();
            List<Patient_Diagnosis> pd = _context.patient_and_diagnosis.Where(a => a.patientid == StaticStuff.patient.id).ToList();
            List<Diagnosis> diagnoses= new List<Diagnosis>();
            foreach (var v in pd)
            {
                diagnoses.Add(_context.diagnosis.Where(d => d.id == v.diagnosisid).ToList()[0]);
            }
            model.diagnosis= diagnoses;
            return View(model);
        }
		public IActionResult MyChamber()
		{
			AllPatientViewModel model= new AllPatientViewModel();
			int chamber_id = _context.patient.Where(p => p.id == StaticStuff.patient.id).ToList()[0].chamberid;
			model.chamber = _context.chamber.Where(c => c.id == chamber_id).ToList()[0];
			return View(model);
		}
		public IActionResult MySchedule()
		{
			AllPatientViewModel model = new AllPatientViewModel();
			model.schedules = _context.schedule.Where(b => b.patientid == StaticStuff.patient.id).ToList();
			List<Doctor> d = new List<Doctor>();
			foreach (var v in model.schedules)
			{
				d.Add(_context.doctor.Where(c => c.id == v.doctorid).ToList()[0]);
			}
			model.doctors = d;
			return View(model);
		}
		
	}
	
}
