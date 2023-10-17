using Microsoft.EntityFrameworkCore;
using MusicProject.sakila;

var builder = WebApplication.CreateBuilder(args);



// Load appsettings.json
builder.Configuration.AddJsonFile("appsettings.json");

// Add services to the container.
builder.Services.AddControllersWithViews();

// Configuration for the DbContext
// Configuration for the DbContext
var connectionString = builder.Configuration.GetConnectionString("MusicConnection");
var serverVersion = ServerVersion.AutoDetect(connectionString); // Use AutoDetect to determine the server version based on the connection string

builder.Services.AddDbContext<MusicDbContext>(options => options
    .UseMySql(connectionString, serverVersion));

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

