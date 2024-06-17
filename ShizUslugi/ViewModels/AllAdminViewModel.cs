using ShizUslugi.Models;
using System.Security.Permissions;
namespace ShizUslugi.ViewModels
{
	public class AllAdminViewModel : AllDoctorViewModel
	{
		public bool IsEdit { get; set; }
		public bool IsChamberOverfilled { get; set; }
		public bool IsInputActivate { get; set; }
		public bool IsUserExisting { get; set; }
		public bool IsFieldEmpty { get; set; } 
		public bool IsFieldOverfilled { get; set; }
		public string FieldName { get; set; }
		public Account account { get; set; }
	}
}
