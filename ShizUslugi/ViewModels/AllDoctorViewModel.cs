using ShizUslugi.Models;

namespace ShizUslugi.ViewModels
{
	public class AllDoctorViewModel
	{
		public Doctor doctor { get; set; }
		public List<Patient> patients { get; set; }
		public List<Chamber> chambers { get; set; }
	}
}
