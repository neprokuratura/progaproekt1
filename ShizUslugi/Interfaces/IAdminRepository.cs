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
		IEnumerable<Patient> GetPatientsByDoctorId(int doctorid);
		Chamber GetChamberById(int id);
		Account GetAccountById(int id);
		Patient GetPatientById(int id);
		Doctor GetDoctorById(int id);
		Doctor_Patient_id GetDoctor_Patient_id(int doctorid, int patientid);
		IEnumerable<Account> GetAccountsByLogin(string login);
		bool IsConnectionExisting(int doctorid, int patientid);
		bool UpdatePatient(Patient patient);
		bool UpdateDoctor(Doctor doctor);
		bool AddPatient(Patient patient);
		bool AddAccount(Account account);
		bool AddSchedule(Schedule schedule);
		bool AddDoctorPatient(Doctor_Patient_id doctor_paitient_id);
		bool DeleteSchedule(Schedule schedule);
		bool DeleteDoctorPatient(Doctor_Patient_id doctor_patient_id);
		bool Save();
	}
}
