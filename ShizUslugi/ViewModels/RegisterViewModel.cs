using ShizUslugi.Models;
namespace ShizUslugi.ViewModels
{
	public class RegisterViewModel : Doctor
	{
		public Account account { get; set; }
		public bool IsUserExisting { get; set; }
		public bool IsFieldOverfilled { get; set; }
		public bool IsFieldEmpty { get; set; } = true;
		public string FieldName { get; set; }
	}
}
