namespace ShizUslugi.Models
{
	public class Doctor_Patient_id
	{
		public int id { get; set; }
		public int doctorid {get; set; }
		public int patientid { get; set; }

		public Doctor doctor { get; set; }
		public Patient patient { get; set; }	
	}
}
