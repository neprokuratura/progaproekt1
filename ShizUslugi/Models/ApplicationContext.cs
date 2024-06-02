using Microsoft.EntityFrameworkCore;

namespace ShizUslugi.Models
{
	public class ApplicationContext : DbContext
	{
		public DbSet<Account> account { get; set; }
		public DbSet<Chamber> chamber { get; set; }
		public DbSet<Diagnosis> diagnosis { get; set; }
		public DbSet<Doctor> doctor { get; set; }
		public DbSet<Doctor_Patient_id> doctor_and_patient { get; set; }
		public DbSet<Patient> patient { get; set; }
		public DbSet<Patient_Diagnosis> patient_and_diagnosis { get; set; }
		public DbSet<Schedule> schedule { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=Durka;Username=postgres;Password=12345678");
		}
	}
}
