using ShizUslugi.Models;
namespace ShizUslugi.ViewModels
{
    public class AllPatientViewModel
    {
        public List<Doctor> Doctors { get; set; }
        public List<Schedule> Schedules { get; set; }
		public List<Chamber> chambers { get; set; }
        public List<Diagnosis> diagnosis { get; set; }
		public Patient patient { get; set; }
    }
}
