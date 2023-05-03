using CompaniesReact.database;
using CompaniesReact.database.Interfaces;
using CompaniesReact.database.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;

builder.Services.AddControllersWithViews();
builder.Services.AddTransient<ICompaniesBranchesRepository, CompanyBranchesRepository>();
builder.Services.AddDbContext<AppDbContext>(opt =>
{
    opt.UseNpgsql(config.GetConnectionString("Default"));
});

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
 
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html");

app.Run();
