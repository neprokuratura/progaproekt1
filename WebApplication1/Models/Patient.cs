namespace WebApplication1.Models
{
	public class Patient : Person
	{
		public int chamber_id {get;set;}
		public int rating { get; set; }

		public Chamber chamber { get; set;}	
	}
}
