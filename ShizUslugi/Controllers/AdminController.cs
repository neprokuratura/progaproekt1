using Microsoft.AspNetCore.Mvc;
using ShizUslugi.Models;
using ShizUslugi.Repository;
using ShizUslugi.Interfaces;
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
			return View();
		}
		public IActionResult Patients()
		{
			IEnumerable<Patient> patients = _adminRepository.GetAllPatients();
			IEnumerable<Chamber> chambers = _adminRepository.GetAllChambers();
			return View(patients);
		}
	}
}
