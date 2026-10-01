using BucketListTravel.Data;
using BucketListTravel.Services;
using BucketListTravel.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BucketListTravel
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            string connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
                ?? throw new InvalidOperationException("Connection string was not found.");
            // Add services to the container.
            builder.Services.AddControllersWithViews();
            
            builder.Services.AddDbContext<BucketListTravelDbContext>(options =>
                options.UseSqlServer(connectionString));

            builder.Services.AddScoped<IDestinationService, DestinationService>();

            var app = builder.Build();

            using (var scope = app.Services.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<BucketListTravelDbContext>();
                db.Database.Migrate();
            }

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
