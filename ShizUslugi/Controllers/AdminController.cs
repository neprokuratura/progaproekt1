using Microsoft.AspNetCore.Mvc;
using ShizUslugi.Models;
using ShizUslugi.Repository;
using ShizUslugi.Interfaces;
using ShizUslugi.ViewModels;
using System.Reflection.Metadata.Ecma335;
namespace ShizUslugi.Controllers
{
	public class AdminController : Controller
	{
		private readonly IAdminRepository _adminRepository;
		public AdminController(IAdminRepository adminrepository)
		{
			_adminRepository = adminrepository;
		}
		public IActionResult Index()
		{
			AllAdminViewModel model = new AllAdminViewModel();
			model.doctor = StaticStuff.doctor;
			return View(model);
		}
		public IActionResult Patients()
		{
			AllAdminViewModel model = new AllAdminViewModel();
			model.patients = _adminRepository.GetAllPatients().ToList();
			model.chambers = _adminRepository.GetAllChambers().ToList();
			if (StaticStuff.adminmodel != null)
			{
				model.IsEdit = StaticStuff.adminmodel.IsEdit;
				model.patient = StaticStuff.adminmodel.patient;
			}
			return View(model);
		}
		[HttpGet]
		public IActionResult PatientsEdit(AllAdminViewModel model)
		{
			model.IsEdit = true;
			StaticStuff.adminmodel = model;
			return RedirectToAction("Patients");
		}
		[HttpPost]
		public IActionResult PatientsEditSubmit(AllAdminViewModel model)
		{
			Patient patient_update = _adminRepository.GetPatientById(model.patient.id);
			patient_update.name = model.patient.name;
			patient_update.surname = model.patient.surname;
			patient_update.thirdname = model.patient.thirdname;
			patient_update.rating = model.patient.rating;
			patient_update.chamberid = model.patient.chamberid;
			patient_update.chamber = _adminRepository.GetChamberById(model.patient.chamberid);
			_adminRepository.UpdatePatient(patient_update);
			model.IsEdit = false;
			StaticStuff.adminmodel = model;
			return RedirectToAction("Patients");
		}
	}
}
