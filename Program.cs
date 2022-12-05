using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using csharp_boolflix.Data;
using csharp_boolflix;
using csharp_boolflix.Models.repository;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<_Repository, RepositoryMedia>();

var connectionString = builder.Configuration.GetConnectionString("BoolflixDbContextConnection"); builder.Services.AddDbContext<BoolfixDbContext>(options =>
    options.UseSqlServer(connectionString));builder.Services.AddDbContext<BoolfixDbContext>(options =>
    options.UseSqlServer(connectionString)); builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<BoolfixDbContext>();

// Add services to the container.
builder.Services.AddControllersWithViews();
//da inserirsi sotto a AddControllersWithViews
//builder.Services.AddRazorPages().AddRazorRuntimeCompilation();
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
app.UseAuthentication();

app.UseAuthorization();

app.MapRazorPages();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
