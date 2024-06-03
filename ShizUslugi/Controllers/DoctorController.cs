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
			if (StaticStuff.status)
			{
				StaticStuff.alldiagnoses = _context.diagnosis.ToList();
				AllDoctorViewModel model = new AllDoctorViewModel();
				model.doctor = StaticStuff.doctor;
				return View(model);
			}
			else return RedirectToAction("PatientWarning");
		}
		[HttpGet]
		public IActionResult MyPatients()
		{
			if (StaticStuff.status)
			{
				AllDoctorViewModel model = new AllDoctorViewModel();
				List<Patient> p = new List<Patient>();
				List<Doctor_Patient_id> a = _context.doctor_and_patient.Where(a => a.doctorid == StaticStuff.doctor.id).ToList();
				foreach (var v in a)
				{
					p.Add(_context.patient.Where<Patient>(b => b.id == v.patientid).ToList()[0]);
				}
				model.chambers = _context.chamber.ToList();
				model.patients = p;
				return View(model);
			}
			else return RedirectToAction("PatientWarning");
		}

		[HttpGet]
		public IActionResult MySchedule()
		{
			if (StaticStuff.status)
			{
				AllDoctorViewModel model = new AllDoctorViewModel();
				model.schedules = _context.schedule.Where(b => b.doctorid == StaticStuff.doctor.id).ToList();
				List<Patient> p = new List<Patient>();

				foreach (var v in model.schedules)
				{
					p.Add(_context.patient.Where<Patient>(c => c.id == v.patientid).ToList()[0]);
				}
				model.patients = p;
				return View(model);
			}
			else return RedirectToAction("PatientWarning");
		}
		public IActionResult PatientDiagnoses(AllDoctorViewModel model)
		{
			if(StaticStuff.status)
			{
				if (model.patient == null)
					model = StaticStuff.doctormodel;
				List<Patient_Diagnosis> pd = _context.patient_and_diagnosis.Where(a => a.patientid == model.patient.id).ToList();
				List<Diagnosis> diagnoses = new List<Diagnosis>();
				foreach (var v in pd)
				{
					diagnoses.Add(_context.diagnosis.Where(d => d.id == v.diagnosisid).ToList()[0]);
				}
				model.diagnosis = diagnoses;
				model.patient = _context.patient.Where(p => p.id == model.patient.id).ToList()[0];	
				return View(model);
			}
            else return RedirectToAction("PatientWarning");
        }
		[HttpPost]
		public IActionResult DeletePatientDiagnoses( AllDoctorViewModel model)
		{
			if (StaticStuff.status)
			{
				Patient p = _context.patient.Where(p => p.id == model.patient.id).ToList()[0];
				Diagnosis d = _context.diagnosis.Where(d => d.id == model.singlediagnosis.id).ToList()[0];
				Patient_Diagnosis connection = _context.patient_and_diagnosis.Where(a => a.patientid == model.patient.id 
				&& a.diagnosisid == model.singlediagnosis.id).ToList()[0];
				_context.patient_and_diagnosis.Remove(connection);
				_context.SaveChanges();
				StaticStuff.doctormodel = model;
				return RedirectToAction("PatientDiagnoses");
			}
			else return RedirectToAction("PatientWarning");
		}
		[HttpPost]
		public IActionResult AddPatientDiagnoses( AllDoctorViewModel model)
		{
			if (StaticStuff.status)
			{
				List<Patient_Diagnosis> pd = _context.patient_and_diagnosis.Where(a => a.diagnosisid == model.singlediagnosis.id &&
				a.patientid == model.patient.id).ToList();
				if (pd.Count == 0)
				{
					_context.Add(new Patient_Diagnosis { diagnosisid = model.singlediagnosis.id, patientid = model.patient.id });
					_context.SaveChanges();
				}
				else
				{
					model.hasDiagnosis = true;
				}
				StaticStuff.doctormodel = model;
				return RedirectToAction("PatientDiagnoses");
			}
			else return RedirectToAction("PatientWarning");
		}
		public IActionResult PatientChamber(AllDoctorViewModel model)
		{
			int chamber_id = _context.patient.Where(p => p.id == model.patient.id).ToList()[0].chamberid;
			model.chamber = _context.chamber.Where(c => c.id == chamber_id).ToList()[0];
			model.patients = _context.patient.Where(p => p.chamberid == chamber_id && p.id != model.patient.id).ToList();
			model.patient = _context.patient.Where(p => p.id == model.patient.id).ToList()[0];
			return View(model);
		}
		public IActionResult PersonalCab()
		{
			Account account = _context.account.Where(b => b.id == StaticStuff.doctor.accountid).ToList()[0];
			return View(account);
		}
		[HttpGet]
		public IActionResult ChangePassword()
		{
			var response = new AccountViewModel();
			return View(response);
		}
		[HttpPost]
		public IActionResult ChangePassword(AccountViewModel A)
		{
			if (A.Password1 == A.Password2)
			{
				A.IsPasswordSame = true;
				Account passwordupdate = _context.account.Where(b => b.id == StaticStuff.doctor.accountid).ToList()[0];
				passwordupdate.password = A.Password1;
				_context.account.Update(passwordupdate);
				_context.SaveChanges();
				return RedirectToAction("PersonalCab");
			}
			else
			{
				A.IsPasswordSame = false;
				return View(A);
			}
		}
		public IActionResult PatientWarning()
		{
			return View();
		}
	}
}
