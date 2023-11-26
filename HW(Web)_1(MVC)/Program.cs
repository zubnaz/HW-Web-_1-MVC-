using DataInfo.Data;
using DataInfo.Data.Entitys;
using FluentValidation;
using FluentValidation.AspNetCore;
using HW_Web__1_MVC_.Helpers;
using HW_Web__1_MVC_.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);
string path = builder.Configuration.GetConnectionString("ConnectAzure");
// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<_AutoDbContext>(opts => opts.UseSqlServer(path));


builder.Services.AddIdentity<User, IdentityRole>()
   .AddDefaultTokenProviders()
   .AddDefaultUI()
  .AddEntityFrameworkStores<_AutoDbContext>();


builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());

//builder.Services.AddScoped<IFileServices, LocalFileService>();
builder.Services.AddScoped<IFileServices, AzureFileService>();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromDays(1);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});


var app = builder.Build();
using (IServiceScope scope = app.Services.CreateScope())
{
    var serviceProvider = scope.ServiceProvider;

    SeedExtensions.SeedRoles(serviceProvider).Wait();

    SeedExtensions.SeedAdmin(serviceProvider).Wait();
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

app.UseSession();
app.UseAuthentication();
app.UseAuthorization();
app.MapRazorPages();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
