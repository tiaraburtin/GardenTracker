using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Tracker.Data;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRazorPages();
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

// Add services to the container.


var connectionString = "server=localhost;user=newuser;password=tracker;database=tracker";
var serverVersion = new MySqlServerVersion(new Version(8, 0, 32));

builder.Services.AddDbContext<TrackerDbContext>(dbContextOptions => dbContextOptions.UseMySql(connectionString, serverVersion));


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

app.MapControllerRoute(
	name: "bed",
	pattern: "Bed/{action}/{id?}",
	defaults: new { controller = "Bed", action = "Index" }
);

app.MapControllerRoute(
	name: "seed",
	pattern: "Seed/{action}/{id?}",
	defaults: new { controller = "Seed", action = "Index" }
);

app.Run();
