using ShizUslugi.Models;

namespace ShizUslugi.ViewModels
{
	public class AllDoctorViewModel
	{
		public Doctor doctor { get; set; }
		public List<Patient> patients { get; set; }
		public List<Chamber> chambers { get; set; }
		public List<Schedule> schedules { get; set; }
        public List<Diagnosis> diagnosis { get; set; }
        public Patient patient { get; set; }
		public Diagnosis singlediagnosis { get; set; }
		public bool hasDiagnosis {  get; set; }
    }
}
