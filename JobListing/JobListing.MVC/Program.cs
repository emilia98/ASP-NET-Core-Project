using JobListing.Core.Contracts;
using JobListing.Core.Services;
using JobListing.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using JobListing.Infrastructure.Seeding;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Infrastructure;
using JobListing.Infrastructure.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<JobListingDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MSSQLConnection")));

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true ).AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<JobListingDbContext>();

/*
builder.Services.AddDefaultIdentity<IdentityUser>(options =>
{
    options.SignIn.RequireConfirmedAccount = false;
    options.SignIn.RequireConfirmedEmail = false;
    options.SignIn.RequireConfirmedPhoneNumber = false;
    options.Password.RequireDigit = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.Password.RequiredLength = 8;
})
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<JobListingDbContext>();
*/

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<ITechnologyService, TechnologyService>();
builder.Services.AddScoped<ILanguageService, LanguageService>();
builder.Services.AddScoped<IUserProfileService, UserProfileService>();
builder.Services.AddScoped<ICompanyService, CompanyService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    var services = app.Services;

    using (var serviceScope = app.Services.CreateScope())
    {
        var dbContext = serviceScope.ServiceProvider.GetRequiredService<JobListingDbContext>();
        var db = (dbContext.Database.GetService<IRelationalDatabaseCreator>() as RelationalDatabaseCreator);
        var dbExists = db?.Exists() ?? false;

       // var migrations = dbContext.Database.GetAppliedMigrations();

        if (!dbExists)
        {
            dbContext.Database.Migrate();
            new JobListingDbContextSeeder().SeedAsync(dbContext, serviceScope.ServiceProvider)
            .GetAwaiter().GetResult();
        }
    }
} 
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "Areas",
        pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");

    endpoints.MapDefaultControllerRoute();
    endpoints.MapRazorPages();
});

/*
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();
*/

app.Run();
