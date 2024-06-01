namespace ShizUslugi.Models
{
	public abstract class Person
	{
		public int id { get; set; }
		public string name { get; set; }
		public string surname { get; set; }
		public string third_name { get; set; }
		public int age { get; set; }
		public int account_id { get; set; }

		public Account account { get; set; }
	}
}
