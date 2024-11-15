using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using UserLogin_Project.Models;

namespace UserLogin_Project
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<MyProjectContext>(
                option=>option.UseSqlServer(builder.Configuration.GetConnectionString("Data Source=DESKTOP-AU94EJS;Initial Catalog=MyProject;Integrated Security=True;TrustServerCertificate=True;Trusted_Connection=True")));
            builder.Services.AddSession(option =>
            {
                option.IOTimeout = TimeSpan.FromSeconds(2);
                option.Cookie.HttpOnly = true; // Set cookie as HttpOnly for security
                option.Cookie.IsEssential = true;
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseSession();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Usbm}/{action=LoginView}/{id?}");

            app.Run();
        }
    }
}
