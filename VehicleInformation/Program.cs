using VehicleInformation.Services;
using VehicleInformation.Services.Interfaces;
using VehicleInformation.Models.Helpers;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.Configure<VehicleApiOptions>(builder.Configuration.GetSection("VehicleApi")); 


builder.Services.AddHttpClient<IVehicleApiService, VehicleApiService>();
builder.Services.AddScoped<IVehicleApiService, VehicleApiService>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
