using ShizUslugi.Models;

namespace ShizUslugi.ViewModels
{
	public class AccountViewModel : Account
	{
		public bool IsPasswordCorrect { get; set; } = true;
		public bool IsUserExisting { get; set; } = true;
		public bool IsPasswordSame { get; set; } = true;
		public bool IsFieldOverfilled { get; set; }
		public bool IsFieldEmpty { get; set; }
		public string FieldName { get; set; }
		public string Password1 { get; set; }
		public string Password2 { get; set; }

	}
}
