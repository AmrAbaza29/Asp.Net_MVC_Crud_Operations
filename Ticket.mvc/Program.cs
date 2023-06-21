using Microsoft.EntityFrameworkCore;
using Tickets.BL;
using Tickets.BL.Manager.TicketDeveloper;
using Tickets.DAL;
using Tickets.DAL.Repos;
using Microsoft.AspNetCore.Identity;
using Tickets.mvc.Data;

namespace Tickets.mvc
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var connectionString = "Server=.; Database=TicketsDbEnhanced2; Trusted_Connection=true; Encrypt=false; ";

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<TicketmvcContext>(options =>
             options.UseSqlServer("Server=.; Database=TicketsDbEnhanced2; Trusted_Connection=true; Encrypt=false; "));

            builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<TicketmvcContext>();
            builder.Services.AddScoped<IDepartmentRepo, DepartmentRepo>();
            builder.Services.AddScoped<ITicketRepo, TicketRepo>();
            builder.Services.AddScoped<IDeveloperRepo, DeveloperRepo>();
            builder.Services.AddScoped<ITicketManager, TicketManager>();
            builder.Services.AddScoped<IDepartmentManager, DepartmentManager>();
            builder.Services.AddScoped<IDeveloperManager, DeveloperManager>();
            builder.Services.AddScoped<ITicketDeveloperManager, TicketDeveloperManager>();
            builder.Services.AddScoped<ITicketDeveloperRepo, TicketDeveloperRepo>();
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

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

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}