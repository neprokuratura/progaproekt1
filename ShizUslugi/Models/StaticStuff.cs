using ShizUslugi.ViewModels;
namespace ShizUslugi.Models

{
	public class StaticStuff
	{
		public static Patient patient {  get; set; }
		public static Doctor doctor { get; set; }
		public static bool status {  get; set; }
		public static AllDoctorViewModel doctormodel { get; set; }
		public static List<Diagnosis> alldiagnoses { get; set; }
		//не лучше ли сделать ридонли свойством
		public static int adminid = 3;
		public static AllAdminViewModel adminmodel { get; set; }
	}
}
