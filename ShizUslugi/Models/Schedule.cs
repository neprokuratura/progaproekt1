using System;

namespace ShizUslugi.Models
{
	public class Schedule
	{
		public int id { get; set; }
		public TimeSpan starttime { get; set; }
		public TimeSpan endtime { get; set; }
		public string action { get; set; }
		public int doctorid { get; set; }
		public int patientid { get; set; }
		public Doctor doctor { get; set; }
		public Patient patient { get; set; }
	}
}
