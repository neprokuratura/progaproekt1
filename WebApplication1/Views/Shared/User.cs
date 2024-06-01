namespace WebApplication1.Pages.Shared
{
	public enum user_type {patient, doctor, admin }
	public class User
	{
		public static user_type User_Type = user_type.patient;
	}
}
