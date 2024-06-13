using Microsoft.EntityFrameworkCore;
using ShizUslugi.Interfaces;
using ShizUslugi.Models;

namespace ShizUslugi.Repository
{
	public class AdminRepository : IAdminRepository
	{
		private readonly ApplicationContext _context;
        public AdminRepository(ApplicationContext context)
        {
            _context = context;
        }
		public bool AddPatient(Patient patient)
		{
			_context.Add(patient);
			return Save();
		}
		public async Task <IEnumerable<Patient>> GetAllPatientsAsync()
		{
			return await _context.patient.ToListAsync();
		}
		public async Task <IEnumerable<Patient>> GetPatientsBySurnameAsync(string surname)
		{
			return await _context.patient.Where(s => s.surname == surname).ToListAsync();
		}
		public bool AddSchedule(Schedule schedule)
		{
			_context.Add(schedule);
			return Save();
		}
		public bool DeleteSchedule(Schedule schedule)
		{
			_context.Remove(schedule);
			return Save();
		}
		public bool Save()
		{
			var saved = _context.SaveChanges();
			return saved > 0 ? true : false;
		}
	}
}
