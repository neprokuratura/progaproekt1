
using WebApplication1.Models;

namespace WebApplication1

{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllers();
            var app = builder.Build();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

			using (ApplicationContext Db = new ApplicationContext())
			{
				Chamber asd = new Chamber
				{
					capacity = 100,
					type = "hell",
					area = 10
					
				};
				Db.chamber.Add(asd);
				Db.SaveChanges();
			}
			app.Run();
        }
    }
}