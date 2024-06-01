namespace ShizUslugi.Models
{
	public class Doctor : Person
	{
		public string specialization { get; set; }
		public int cabinet_number { get; set; }
		public int phone_number { get; set; }

		
	}
}
