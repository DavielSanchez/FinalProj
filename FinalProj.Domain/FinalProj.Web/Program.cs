using FinalProj.Infrastructure.Context;
using FinalProj.IOC.Dependencies;
using FinalProj.Web.Contracts;
using FinalProj.Web.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


// Dependencias

builder.Services.ConfigureSalesContext(builder.Configuration.GetConnectionString("SalesContext"));
builder.Services.AddVentaDependecy();
builder.Services.AddScoped<IApiService, ApiService>();

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddHttpClient();

var app = builder.Build();

// Configure the HTTP request pipeline.
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
