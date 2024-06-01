
using WebApplication1.Models;

namespace WebApplication1

{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllers();
            builder.Services.AddMvc();
			builder.Services.AddDbContext<ApplicationContext>();
            var app = builder.Build();
             app.MapControllerRoute(
                 name: "default",
                 pattern: "{controller=Home}/{action=Index}/{id?}");


      
            app.Run();
        }
    }
}