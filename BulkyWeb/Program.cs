using Microsoft.EntityFrameworkCore;
using Web.Infrastracture.Data;
using Web.Infrastracture.Repository;
using Microsoft.AspNetCore.Identity;
using Web.Application;
using Microsoft.AspNetCore.Identity.UI.Services;


namespace BulkyWeb
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddDbContext<BulkyDbContext>(options =>
            
            options.UseSqlServer(builder.Configuration.GetConnectionString("CreateDataBase")));
            builder.Services.AddScoped<IEmailSender, EmailSender>();

           

            builder.Services.AddIdentity<IdentityUser,IdentityRole>().AddEntityFrameworkStores<BulkyDbContext>().AddDefaultTokenProviders();

            builder.Services.ConfigureApplicationCookie(option =>
            {
                option.LoginPath = $"/Identity/Account/Login";
                option.LogoutPath = $"/Identity/Account/Logout";
                option.AccessDeniedPath = $"/Identity/Account/AccessDenied";

            });

            builder.Services.AddAuthentication()
            .AddGoogle(googleOptions =>
            {
                googleOptions.ClientId = "348852961000-guiigja83tsnps1rc6hqebjp7b1lbioh.apps.googleusercontent.com";
                googleOptions.ClientSecret = "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";
            });


            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

            builder.Services.AddRazorPages();


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
            app.UseAuthentication();
            app.UseAuthorization();
            app.MapRazorPages();

            app.MapControllerRoute(
                name: "default",
                pattern: "{area=Customer}/{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
