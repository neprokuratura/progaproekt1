
using WebApplication1.Models;

namespace WebApplication1

{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllers();
			builder.Services.AddRazorPages();
			builder.Services.AddDbContext<ApplicationContext>();
            var app = builder.Build();
            /* app.MapControllerRoute(
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
             }*/
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapRazorPages();

            app.Run();
        }
    }
}