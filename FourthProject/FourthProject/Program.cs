using Microsoft.AspNetCore.Identity;
using Project.DAL.Contexts;
using Project.DAL.Entities;
using Project.DAL.Extensions;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddingServicesForDAL();
builder.Services.AddIdentity<AppUser, IdentityRole>(opt =>
{
    opt.User.RequireUniqueEmail = true;
    opt.Password.RequiredLength = 6;
    opt.Password.RequireLowercase = true;
    opt.Password.RequireUppercase = true;
}
).AddEntityFrameworkStores<FourthDbContext>().AddRoles<IdentityRole>().AddDefaultTokenProviders();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
            name: "areas",
            pattern: "{area:exists}/{controller=Dashboard}/{action=Index}/{id?}"
          );
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
