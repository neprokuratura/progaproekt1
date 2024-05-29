using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Models
{
	public class ApplicationContext : DbContext
	{
		public DbSet<Account> account { get; set; }
		public DbSet<Chamber> chamber { get; set; }
		public DbSet<Diagnosis> diagnosis { get; set; }
		public DbSet<Doctor> doctor { get; set; }
		public DbSet<Doctor_Patient_id> doctor_patient_id { get; set; }
		public DbSet<Drug> drug { get; set; }
		public DbSet<Patient> patient { get; set; }
		public DbSet<Patient_Diagnosis> Diagnosis { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=123;Username=postgres;Password=123");
		}
	}
}
