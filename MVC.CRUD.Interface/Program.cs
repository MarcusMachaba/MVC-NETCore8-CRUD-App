using AspNetCoreHero.ToastNotification;
using AspNetCoreHero.ToastNotification.Extensions;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MVC.CRUD.Interface.DAL;
using MVC.CRUD.Interface.Models.Entities;
using MVC.CRUD.Interface.ServiceHelpers;
using System.Xml.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<CRUDContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnectionString")));

builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();
builder.Services.AddScoped<IClientService, ClientService>();

builder.Services.AddIdentity<User, IdentityRole>(options =>
{
    options.SignIn.RequireConfirmedAccount = true;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireDigit = false;

    //options.Password.RequireDigit = false;
    //options.Password.RequiredLength = 2;
    //options.Password.RequireUppercase = false;
    //options.Password.RequireLowercase = false;
    //options.Password.RequireNonAlphanumeric = false;
    //options.Password.RequiredUniqueChars = 0;
    //options.Lockout.AllowedForNewUsers = true;
    //options.Lockout.MaxFailedAccessAttempts = 5;
    //options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromSeconds(30);
})
    .AddEntityFrameworkStores<CRUDContext>()
    .AddDefaultUI()
    .AddDefaultTokenProviders();

builder.Services.AddControllersWithViews();


builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
        .AddCookie(cookieOptions =>
        {
            cookieOptions.LoginPath = "/Auth/Signin/";
            cookieOptions.ExpireTimeSpan = TimeSpan.FromMinutes(15);
            cookieOptions.SlidingExpiration = true;
            cookieOptions.AccessDeniedPath = "/Auth/AccessDenied";//"/Forbidden/";
        });

builder.Services.AddNotyf(o =>
{
    o.DurationInSeconds = 10;
    o.IsDismissable = true;
    o.HasRippleEffect = true;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
else
{
    //app.UseBrowserLink();
}

app.UseNotyf();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Auth}/{action=Signin}/{id?}");

//seed data for users & roles & userRoles
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var loggerFactory = services.GetRequiredService<ILoggerFactory>();
    try
    {
        var context = services.GetRequiredService<CRUDContext>();
        var userManager = services.GetRequiredService<UserManager<User>>();
        var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
        await ContextSeed.SeedRolesAsync(userManager, roleManager);
        await ContextSeed.SeedSuperAdminAsync(userManager, roleManager);
        await ContextSeed.SeedClientsAsync(context);
    }
    catch (Exception ex)
    {
        var logger = loggerFactory.CreateLogger<Program>();
        logger.LogError(ex, "An error occurred while seeding the DB.");
    }
}

app.Run();
