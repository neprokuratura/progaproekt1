using ShizUslugi.Models;
namespace ShizUslugi.VIewModels
{
    public class AllPatientViewModel
    {
        public List<Patient> Patients { get; set; }
        public List<Doctor> Doctorss { get; set; }
        public List<Doctor_Patient_id> DocPaitid { get; set; }
        public List<Diagnosis> Diagnoses { get; set; }
        public List<Patient_Diagnosis> PaitDiagid { get; set; }
        public List<Chamber> Chambers { get; set; }
    }
}
