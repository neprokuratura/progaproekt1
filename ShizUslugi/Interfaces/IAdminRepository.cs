using ShizUslugi.Models;

namespace ShizUslugi.Interfaces
{
	public interface IAdminRepository
	{
		IEnumerable<Patient> GetAllPatients();
		IEnumerable<Chamber> GetAllChambers();
		IEnumerable<Patient> GetPatientsBySurname(string surname);
		Chamber GetChamberById(int id);
		Account GetAccountById(int id);
		Patient GetPatientById(int id);
		bool UpdatePatient(Patient patient);
		bool AddPatient(Patient patient);
		bool AddSchedule(Schedule schedule);
		bool DeleteSchedule(Schedule schedule);
		bool Save();
	}
}
