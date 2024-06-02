﻿namespace ShizUslugi.Models
{
	public class Diagnosis
	{
		public int id { get; set; }
		public string severeness { get; set; }
		public string description { get; set; }
		public int drugid { get; set; }
		public string name { get; set; }

		public Drug drug { get; set; }
	}
}
