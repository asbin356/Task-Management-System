using Microsoft.AspNetCore.Authentication.Cookies;
using Serilog;
using Task_Management_System.Data;
using Task_Management_System.Services;
using Task_Management_System.Services.Implementations;

namespace Task_Management_System
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services.AddScoped<DapperContext>(provider => new DapperContext(connectionString));
            builder.Services.AddScoped<ITasksService, TasksService>();
            builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            builder.Services.AddScoped<DataSeeder>();
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.LoginPath = "/Accounts/Login";
                    options.LogoutPath = "/Accounts/Logout";
                    options.LogoutPath = "/Accounts/AccessDenied";
                });

            var logger = new LoggerConfiguration()
                .WriteTo.Console()
                .WriteTo.File("Logs/TMS_logs.txt", rollingInterval: RollingInterval.Minute)
                .MinimumLevel.Warning()
                .CreateLogger();

            builder.Logging.ClearProviders();
            builder.Services.AddSerilog(logger);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(30);
                //Note: Nobody can access the cookie from the javascript, it can access only by the URL
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            DataSeeding(app);

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSession();
            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }

        private static async void DataSeeding(WebApplication app)
        {
            using (var scope = app.Services.CreateScope())
            {
                var dsObject = scope.ServiceProvider.GetRequiredService<DataSeeder>();
                await dsObject.SeedDataAsync();
            }
        }
    }
}
