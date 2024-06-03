using ShizUslugi.ViewModels;
namespace ShizUslugi.Models

{
	public class StaticStuff
	{
		public static Patient patient {  get; set; }
		public static Doctor doctor { get; set; }
		public static bool status {  get; set; }
		public static AllDoctorViewModel doctormodel { get; set; }
	}
}
