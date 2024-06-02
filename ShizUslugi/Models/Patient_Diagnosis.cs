namespace ShizUslugi.Models
{
	public class Patient_Diagnosis
	{
		public int id { get; set; }
		public int patientid { get; set; }

		public int diagnosisid { get; set; }

		public Patient patient { get; set; }

		public Diagnosis diagnosis { get; set;} 
	}
}
