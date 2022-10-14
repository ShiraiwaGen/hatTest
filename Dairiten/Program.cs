using Dairiten.Areas.Identity;
using Dairiten.Data;
using Dairiten.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<AppUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddErrorDescriber<IdentityErrorDescriberJP>();
builder.Services.AddRazorPages(options =>
{
    options.Conventions.AddPageRoute("/Account/Login", "");
});

builder.Services.Configure<IdentityOptions>(options =>
{
    // パスワードに英数以外を含む必要があるか
    options.Password.RequireNonAlphanumeric = true;
    // パスワードに大文字を含む必要があるか
    options.Password.RequireUppercase = true;
    // パスワードに小文字を含む必要があるか
    options.Password.RequireLowercase = true;
    // パスワードに数値を含む必要があるか
    options.Password.RequireDigit = true;
});

builder.Services.AddDistributedMemoryCache();

builder.Services.ConfigureApplicationCookie(options =>
{
    options.Cookie.HttpOnly = true;
    options.ExpireTimeSpan = TimeSpan.FromMinutes(60);
    options.LoginPath = "/Identity/Account/Login";
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

app.Run();
