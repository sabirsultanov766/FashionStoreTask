namespace FashionStoreTask.MVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllersWithViews();
            var app = builder.Build();
            app.UseStaticFiles();
            app.MapControllerRoute(
                name: "default",
                pattern: "{Controller=Home}/{Action=Index}"
                );


            app.Run();
        }
    }
}
