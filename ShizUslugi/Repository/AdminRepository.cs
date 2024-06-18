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
		public IEnumerable<Diagnosis> GetAllDiagnoses()
		{
			return _context.diagnosis.ToList();
		}
		public IEnumerable<Doctor> GetAllDoctors()
		{
			return _context.doctor.ToList();
		}
		public IEnumerable<Account> GetAllAccounts()
		{
			return _context.account.ToList();
		}
		public IEnumerable<Patient> GetAllPatientsInChamber(int chamberid)
		{
			return _context.patient.Where(p => p.chamberid == chamberid).ToList();
		}
		public IEnumerable<Patient> GetPatientsByDoctorId(int doctorid)
		{
			List<Patient> patients = new List<Patient>();
			List<Doctor_Patient_id> doc_pat = _context.doctor_and_patient.Where(dp => dp.doctorid == doctorid).ToList();
			foreach(Doctor_Patient_id dp  in doc_pat)
			{
				patients.Add(_context.patient.Where(p => p.id == dp.patientid).ToList()[0]);
			}
			return patients;
		}
		public Chamber GetChamberById(int id)
		{
			return _context.chamber.Where(c => c.id == id).ToList()[0];
		}
		public Account GetAccountById(int id)
		{
			return _context.account.Where(a => a.id == id).ToList()[0];
		}
		public Patient GetPatientById(int id)
		{
			return _context.patient.Where(p => p.id == id).ToList()[0];
		}
		public Doctor GetDoctorById(int id)
		{
			return _context.doctor.Where(d => d.id == id).ToList()[0];
		}
		public Doctor_Patient_id GetDoctor_Patient_id(int doctorid, int patientid)
		{
			return _context.doctor_and_patient.Where(dp => dp.doctorid == doctorid && dp.patientid == patientid).ToList()[0];
		}
		public IEnumerable<Account> GetAccountsByLogin(string login)
		{
			return _context.account.Where(a => a.login == login).ToList();
		}
		public bool IsConnectionExisting(int doctorid, int patientid)
		{
			return _context.doctor_and_patient.Where(dp => dp.doctorid == doctorid && dp.patientid == patientid).Any();
		}
		public bool UpdatePatient(Patient patient)
		{
			_context.patient.Update(patient);
			return Save();
		}
		public bool UpdateDoctor(Doctor doctor)
		{
			_context.doctor.Update(doctor);
			return Save();
		}
		public bool AddAccount(Account account)
		{
			_context.Add(account);
			return Save();
		}
		public bool AddSchedule(Schedule schedule)
		{
			_context.Add(schedule);
			return Save();
		}
		public bool AddDoctorPatient(Doctor_Patient_id doctor_patient_id)
		{
			_context.Add(doctor_patient_id);
			return Save();
		}
		public bool DeleteSchedule(Schedule schedule)
		{
			_context.Remove(schedule);
			return Save();
		}
		public bool DeleteDoctorPatient(Doctor_Patient_id doctor_patient_id)
		{
			_context.Remove(doctor_patient_id);
			return Save();
		}
		public bool Save()
		{
			var saved = _context.SaveChanges();
			return saved > 0 ? true : false;
		}
	}
}
