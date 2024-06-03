using ShizUslugi.Models;
namespace ShizUslugi.ViewModels
{
    public class AllPatientViewModel
    {
        public List<Doctor> doctors { get; set; }
        public List<Schedule> schedules { get; set; }
		public Chamber chamber { get; set; }
        public List<Diagnosis> diagnosis { get; set; }
		public Patient patient { get; set; }
    }
}
