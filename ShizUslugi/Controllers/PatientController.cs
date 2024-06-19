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
			if (!StaticStuff.status && StaticStuff.patient != null)
			{
				AllPatientViewModel data = new AllPatientViewModel();
				data.patient = StaticStuff.patient;
				return View(data);
			}
			else return RedirectToAction("PatientWarning", "Doctor");
		}
		public IActionResult MyDoctors()
		{
			if (!StaticStuff.status && StaticStuff.patient != null)
			{
				AllPatientViewModel model = new AllPatientViewModel();
				List<Doctor_Patient_id> dp = _context.doctor_and_patient.Where(a => a.patientid == StaticStuff.patient.id).ToList();
				List<Doctor> doctors = new List<Doctor>();
				foreach (var v in dp)
				{
					doctors.Add(_context.doctor.Where(d => d.id == v.doctorid).ToList()[0]);
				}
				model.doctors = doctors;
				return View(model);
			}
			else return RedirectToAction("PatientWarning", "Doctor");
		}
		public IActionResult MyDiagnoses()
		{
			if (!StaticStuff.status && StaticStuff.patient != null)
			{
				AllPatientViewModel model = new AllPatientViewModel();
				List<Patient_Diagnosis> pd = _context.patient_and_diagnosis.Where(a => a.patientid == StaticStuff.patient.id).ToList();
				List<Diagnosis> diagnoses = new List<Diagnosis>();
				foreach (var v in pd)
				{
					diagnoses.Add(_context.diagnosis.Where(d => d.id == v.diagnosisid).ToList()[0]);
				}
				model.diagnosis = diagnoses;
				return View(model);
			}
			else return RedirectToAction("PatientWarning", "Doctor");
		}
		public IActionResult MyChamber()
		{
			if (!StaticStuff.status && StaticStuff.patient != null)
			{
				AllPatientViewModel model = new AllPatientViewModel();
				int chamber_id = _context.patient.Where(p => p.id == StaticStuff.patient.id).ToList()[0].chamberid;
				model.chamber = _context.chamber.Where(c => c.id == chamber_id).ToList()[0];
				model.patients = _context.patient.Where(p => p.chamberid == chamber_id && p.id != StaticStuff.patient.id).ToList();
				return View(model);
			}
			else return RedirectToAction("PatientWarning", "Doctor");
		}
		public IActionResult MySchedule()
		{
			if (!StaticStuff.status && StaticStuff.patient != null)
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
			else return RedirectToAction("PatientWarning", "Doctor");
		}
		public IActionResult PersonalCab()
		{
			if (!StaticStuff.status && StaticStuff.patient != null)
			{
				Account account = _context.account.Where(b => b.id == StaticStuff.patient.accountid).ToList()[0];
				return View(account);
			}
			else return RedirectToAction("PatientWarning", "Doctor");
		}
		[HttpGet]
		public IActionResult ChangePassword()
		{
			if (!StaticStuff.status && StaticStuff.patient != null)
			{
				var response = new AccountViewModel();
				return View(response);
			}
			else return RedirectToAction("PatientWarning", "Doctor");
		}
		[HttpPost]
		public IActionResult ChangePassword(AccountViewModel A)
		{
			if ((A.Password1 == null) || (A.Password2 == null))
			{
				A.IsFieldEmpty = true;
				return View(A);
			}
			else if (A.Password1.Length > 20 || A.Password2.Length > 20)
			{
				A.IsFieldOverfilled = true;
				return View(A);
			}
			else if (A.Password1 != A.Password2)
			{
				A.IsPasswordSame = false;
				return View(A);
			}
			else
			{
				A.IsFieldEmpty = false;
				A.IsPasswordSame = true;
				A.IsFieldOverfilled = false;
				Account passwordupdate = _context.account.Where(b => b.id == StaticStuff.patient.accountid).ToList()[0];
				passwordupdate.password = A.Password1;
				_context.account.Update(passwordupdate);
				_context.SaveChanges();
				return RedirectToAction("PersonalCab");
			}
		}
		public IActionResult Logout()
		{
			StaticStuff.patient = null;
			StaticStuff.doctor = null;
			StaticStuff.status = false;
			StaticStuff.doctormodel = null;
			StaticStuff.alldiagnoses = null;
			return RedirectToAction("Index", "Home");
		}
	}
}
