using ShizUslugi.Models;
namespace ShizUslugi.VIewModels
{
    public class AllPatientViewModel
    {
        public List<Doctor> Doctors { get; set; }
        public List<Schedule> Schedules { get; set; }
        public Patient patient { get; set; }
    }
}
