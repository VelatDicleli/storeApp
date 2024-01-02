using Microsoft.EntityFrameworkCore;
using StoreApp.Models;
using StoreApp.DataAccess.GenericRepo.Concrete;
using StoreApp.DataAccess.Abstract;
using StoreApp.DataAccess.Concrete;
using StoreApp.DataAccess.GenericRepo.Absract;
using StoreApp.Business.Abstract;
using StoreApp.Business.Concrete;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Net;
using StoreApp.Entities.Models;
using StoreApp.Infrastructer.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();


builder.Services.ConfigureDbContext(builder.Configuration);
builder.Services.ConfigureSession();
builder.Services.ConfigureRepositoryRegistration();
builder.Services.ConfigureServiceRegistration();
builder.Services.ConfigureRouting();
builder.Services.ConfigureIdentity();
builder.Services.ConfigureApplicationCookie();
builder.Services.AddAutoMapper(typeof(Program));

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
app.UseSession();//gerekli
app.UseRouting();

app.UseAuthentication();  // bu middleware kýsmý routing ve endpoints arasýnda olmalý
app.UseAuthorization();

app.UseEndpoints(endpoints =>   {
    endpoints.MapAreaControllerRoute(
    name: "admin",
    areaName: "Admin",
    pattern: "Admin/{controller=Dashboard}/{action=Index}/{id?}");

    
    
    endpoints.MapControllerRoute(name: "default",pattern: "{controller=Home}/{action=Index}/{id?}");

    endpoints.MapRazorPages();

     }

);
app.ConfigureDefaultAdminUser();
app.ConfigureAndCheckMigration();

app.Run();
