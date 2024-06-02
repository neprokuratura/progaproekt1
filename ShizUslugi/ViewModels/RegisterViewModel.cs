using ShizUslugi.Models;
namespace ShizUslugi.ViewModels
{
	public class RegisterViewModel : Doctor
	{
		public Account account { get; set; }
		public bool IsUserExisting { get; set; }
	}
}
