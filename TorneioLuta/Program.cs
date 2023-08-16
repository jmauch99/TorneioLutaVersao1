using System;
using Microsoft.EntityFrameworkCore;
using TorneioLuta.Repositories;
using TorneioLuta.Services;

namespace TorneioLuta
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<TorneioContext>(options =>
           options.UseSqlServer(builder.Configuration.GetConnectionString("DataBase")));


            builder.Services.AddScoped<ILutadorService, LutadorService>();
            builder.Services.AddScoped<ILutadorRepository, LutadorRepository>();
            // Add services to the container.
            builder.Services.AddControllersWithViews();

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