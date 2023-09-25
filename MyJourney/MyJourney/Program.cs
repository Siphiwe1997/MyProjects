using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MyJourney.Data;
using MyJourney.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));


builder.Services.AddRouting(options =>
{
    options.LowercaseUrls = true;
    options.AppendTrailingSlash = true;
});
builder.Services.AddDbContext<AppIdentityDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("IdentityConnection")));

builder.Services.AddIdentity<IdentityUser, IdentityRole>(opts => {
    opts.Password.RequiredLength = 6;
    opts.Password.RequireNonAlphanumeric = false;
    opts.Password.RequireLowercase = false;
    opts.Password.RequireUppercase = false;
    opts.Password.RequireDigit = false;
    opts.User.RequireUniqueEmail = true;
    opts.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyz";
}).AddEntityFrameworkStores<AppIdentityDbContext>();

builder.Services.AddScoped<IPasswordValidator<IdentityUser>, CustomPasswordValidator>();
builder.Services.AddScoped<IUserValidator<IdentityUser>, CustomUserValidator>();
var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();

// most specific route - 5 required segments
app.MapControllerRoute(
    name: "paging_and_sorting",
    pattern: "{controller}/{action}/{id}/page{num}/sort-by-{sortby}");

// less specific route - 4 required segments
app.MapControllerRoute(
    name: "paging",
    pattern: "{controller}/{action}/{id}/page{num}");

// least specific route - 0 required segments 

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
//pattern: "{controller=Home}/{action=Index}/{id?}/{Slug?}");
SeedData.EnsurePopulated(app);
SeedIdentityData.EnsurePopulated(app);

app.Run();