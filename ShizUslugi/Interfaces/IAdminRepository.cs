using ShizUslugi.Models;

namespace ShizUslugi.Interfaces
{
	public interface IAdminRepository
	{
		IEnumerable<Patient> GetAllPatients();
		IEnumerable<Chamber> GetAllChambers();
		IEnumerable<Diagnosis> GetAllDiagnoses();
		IEnumerable<Doctor> GetAllDoctors();
		IEnumerable<Account> GetAllAccounts();
		IEnumerable<Patient> GetPatientsBySurname(string surname);
		IEnumerable<Patient> GetAllPatientsInChamber(int chamberid);
		Chamber GetChamberById(int id);
		Account GetAccountById(int id);
		Patient GetPatientById(int id);
		IEnumerable<Account> GetAccountsByLogin(string login);
		bool UpdatePatient(Patient patient);
		bool AddPatient(Patient patient);
		bool AddAccount(Account account);
		bool AddSchedule(Schedule schedule);
		bool DeleteSchedule(Schedule schedule);
		bool Save();
	}
}
