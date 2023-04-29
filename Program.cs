using System;
using Microsoft.EntityFrameworkCore;
using Tracker.Data;
using Microsoft.AspNetCore.Identity;


var builder = WebApplication.CreateBuilder(args);

var connectionString = "server=localhost;user=newuser1;password=password;database=gardentracker1";
var serverVersion = new MySqlServerVersion(new Version(8, 0, 29));
builder.Services.AddDbContext<TrackerDbContext>(dbContextOptions => dbContextOptions.UseMySql(connectionString, serverVersion));
// Add services to the container.
builder.Services.AddControllersWithViews();



builder.Services.AddDefaultIdentity<IdentityUser>
(options =>
{
    options.SignIn.RequireConfirmedAccount = true;
    options.Password.RequireDigit = false;
    options.Password.RequiredLength = 10;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = true;
    options.Password.RequireLowercase = false;
}).AddEntityFrameworkStores<TrackerDbContext>();



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

app.UseAuthentication();;
app.UseAuthorization();
app.MapRazorPages();
app.MapControllers();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
