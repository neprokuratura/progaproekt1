using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Models
{
	public class ApplicationContext : DbContext
	{
		public DbSet<Chamber> chamber { get; set; }
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=123;Username=postgres;Password=123");
		}
	}
}
