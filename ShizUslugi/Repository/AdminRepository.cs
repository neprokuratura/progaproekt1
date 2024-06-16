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
		public IEnumerable<Patient> GetAllPatients()
		{
			return  _context.patient.ToList();
		}
		public IEnumerable<Patient> GetPatientsBySurname(string surname)
		{
			return _context.patient.Where(s => s.surname == surname).ToList();
		}
		public IEnumerable<Chamber> GetAllChambers()
		{
			return _context.chamber.ToList();
		}
		public bool UpdatePatient(Patient patient)
		{
			_context.patient.Update(patient);
			return Save();
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
