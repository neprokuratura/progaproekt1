using ShizUslugi.Models;

namespace ShizUslugi.Interfaces
{
	public interface IAdminRepository
	{
		Task<IEnumerable<Patient>> GetAllPatientsAsync();
		public Task<IEnumerable<Patient>> GetPatientsBySurnameAsync(string surname);
		bool AddPatient(Patient patient);
		bool AddSchedule(Schedule schedule);
		bool DeleteSchedule(Schedule schedule);
		bool Save();
	}
}
