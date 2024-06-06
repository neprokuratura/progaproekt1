namespace ShizUslugi.Models
{
	public abstract class Person
	{
		public int id { get; set; }
		public string name { get; set; }
		public string surname { get; set; }
		public string? thirdname { get; set; }
		public int accountid { get; set; }

		public Account account { get; set; }
	}
}
