using ShizUslugi.Models;

namespace ShizUslugi.ViewModels
{
	public class AccountViewModel : Account
	{
		public bool IsPasswordCorrect { get; set; } = true;
		public bool IsUserExisting { get; set; } = true;
	}
}
