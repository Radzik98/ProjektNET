using Microsoft.EntityFrameworkCore;
using ProjektNET.Data;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Extensions;
using ProjektNET.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddDbContext<UserDbContext>(options =>
    options.UseInMemoryDatabase("name"));

builder.Services.AddDbContext<OfferDbContext>(options =>
    options.UseInMemoryDatabase("name"));

builder.Services.AddDbContext<RateDbContext>(options =>
    options.UseInMemoryDatabase("name"));

builder.Services.AddMemoryCache();
builder.Services.AddSession();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie();

// void ConfigureServices(IServiceCollection services)
// {
//     services.AddIdentity<ProjektNET.Models.User, IdentityRole>()
//         .AddEntityFrameworkStores<UserDbContext>()
//         .AddDefaultTokenProviders()
//         .AddRoles<IdentityRole>();


// }

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseAuthentication();

app.UseEndpoints(endpoints =>
{
    endpoints.MapRazorPages();
});



app.Run();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie("Cookies", options =>
    {
        options.LoginPath = "/Login";
        options.LogoutPath = "/Logout";
        options.AccessDeniedPath = "/AccessDenied";
        options.ReturnUrlParameter = "ReturnUrl";
    });


