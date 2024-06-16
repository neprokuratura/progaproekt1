using ShizUslugi.Models;

namespace ShizUslugi.Interfaces
{
	public interface IAdminRepository
	{
		IEnumerable<Patient> GetAllPatients();
		IEnumerable<Chamber> GetAllChambers();
		public IEnumerable<Patient> GetPatientsBySurname(string surname);
		bool AddPatient(Patient patient);
		bool AddSchedule(Schedule schedule);
		bool DeleteSchedule(Schedule schedule);
		bool Save();
	}
}
