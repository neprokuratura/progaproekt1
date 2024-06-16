using Microsoft.AspNetCore.Mvc;
using ShizUslugi.Models;
using ShizUslugi.Repository;
using ShizUslugi.Interfaces;
using ShizUslugi.ViewModels;
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
			IEnumerable<Patient> patients = _adminRepository.GetAllPatients();
			IEnumerable<Chamber> chambers = _adminRepository.GetAllChambers();
			return View(patients);
		}
	}
}
