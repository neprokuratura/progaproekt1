namespace WebApplication1.Models
{
	public class Doctor_Patient_id
	{
		public int id { get; set; }
		public int Doctor_id {get; set; }
		public int Patient_id { get; set; }

		public Doctor doctor { get; set; }
		public Patient patient { get; set; }	
	}
}
