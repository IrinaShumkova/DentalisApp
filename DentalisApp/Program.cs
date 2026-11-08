using DentalisApp.Data;
using DentalisApp.Services;
using DentalisApp.Services.Contracts;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace DentalisApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            string connectionString = builder.Configuration.GetConnectionString("SQLServerDev")
             ?? throw new InvalidOperationException("Connection string 'SQLServerDev' not found.");

            builder.Services.AddDbContext<DentalisAppDbContex>(options =>
                options.UseSqlServer(connectionString));

            builder.Services.AddDatabaseDeveloperPageExceptionFilter();

            builder.Services.AddDefaultIdentity<IdentityUser>
            (options =>
            {
                ConfigureIdentityOptions(options, builder.Configuration);


            })
                .AddEntityFrameworkStores<DentalisAppDbContex>();

            builder.Services.AddScoped<IPatientService, PatientService>();

            builder.Services.AddControllersWithViews();

            WebApplication app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            app.MapRazorPages();

            app.Run();
        }

        private static void ConfigureIdentityOptions(IdentityOptions options, ConfigurationManager configuration)
        {
                options.Password.RequireDigit =
                configuration.GetValue<bool>("Identity:Password:RequireDigit");
                options.Password.RequireNonAlphanumeric =
                configuration.GetValue<bool>("Identity:Password:RequireNonAlphanumeric");
                options.Password.RequireUppercase =
                configuration.GetValue<bool>("Identity:Password:RequireUppercase");
                options.Password.RequireLowercase =
                configuration.GetValue<bool>("Identity:Password:RequireLowercase");
                options.Password.RequiredUniqueChars =
                configuration.GetValue<int>("Identity:Password:RequiredUniqueChars");
                options.Password.RequiredLength =
                configuration.GetValue<int>("Identity:Password:RequiredLength");
                options.User.RequireUniqueEmail =
                configuration.GetValue<bool>("Identity:User:RequireUniqueEmail");
                options.SignIn.RequireConfirmedAccount =
                configuration.GetValue<bool>("Identity:Signin:RequireConfirmedAccount");
            
        }
    }
}
