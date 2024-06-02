namespace ShizUslugi.Models
{
	public class Doctor : Person
	{
		public string specialization { get; set; }
		public int cabinetnumber { get; set; }
		public string phonenumber { get; set; }
	}
}
