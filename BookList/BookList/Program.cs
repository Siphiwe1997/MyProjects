using Microsoft.EntityFrameworkCore;
using BookList.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IBookRepository, BookRepository>();

//builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(
//        builder.Configuration.GetConnectionString("Connection")));

////Database Option 2: SQLite
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddRouting(options =>
{
    options.LowercaseUrls = true;
    options.AppendTrailingSlash = true;
});

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
    pattern: "{controller=Home}/{action=Index}/{id?}/{Slug?}");
SeedData.EnsurePopulated(app);
app.Run();
