using AspNetCoreIdentityDemo.Models.Datas;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var cnnStr = builder.Configuration.GetConnectionString("DefaultConnetion")
    ?? throw new InvalidOperationException("string de connecção nula"); 

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ApplicationDbContext>(options=>options.UseSqlServer(cnnStr));

builder.Services.AddIdentity<IdentityUser, IdentityRole>(options =>
{
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireUppercase = true;
    options.Password.RequiredLength = 8;
    options.Password.RequiredUniqueChars = 4; 
})
    .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.ConfigureApplicationCookie(opt => opt.LoginPath = "/Account/Login"); 

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication(); 
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
