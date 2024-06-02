namespace ShizUslugi.Models
{
	public class Patient : Person
	{
		public int chamberid {get;set;}
		public int rating { get; set; }

		public Chamber chamber { get; set;}	
	}
}
