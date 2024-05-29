namespace WebApplication1.Models
{
	public class Patient_Diagnosis
	{
		public int id { get; set; }
		public int Patient_id { get; set; }

		public int Doctor_id { get; set; }

		public Patient patient { get; set; }

		public Diagnosis diagnosis { get; set;} 
	}
}
