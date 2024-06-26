using Microsoft.EntityFrameworkCore;
using WebVRMS.Contracts;
using WebVRMS.Models;
using WebVRMS.Services;

var builder = WebApplication.CreateBuilder(args);

// register dbcontext ef
builder.Services.AddDbContext<VehicleRentalDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

// Add services to the container.
builder.Services.AddControllersWithViews();

// Inject DI
builder.Services.AddScoped<IVehicle, VehiclesService>();
builder.Services.AddScoped<IRental, RentalsService>();
builder.Services.AddScoped<IInvoice, InvoiceService>();
builder.Services.AddScoped<IPayment, PaymentsService>();


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
