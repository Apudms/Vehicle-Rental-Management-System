using Microsoft.EntityFrameworkCore;
using WebVRMS.Contracts;
using WebVRMS.Models;
using WebVRMS.Services;

var builder = WebApplication.CreateBuilder(args);

//register dbcontext untuk EF
builder.Services.AddDbContext<VehicleRentalDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("ConnStr"));
});

//menambahkan modul mvc
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IRental, RentalsService>();
builder.Services.AddScoped<IInvoice, InvoiceService>();

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
