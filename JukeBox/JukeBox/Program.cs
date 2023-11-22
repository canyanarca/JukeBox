using JukeBox.Config;
using JukeBox.Models.Context;
using JukeBox.Models.Entities;
using JukeBox_API.Models.Context;
using JukeBox_API.Models.Entities;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpClient("MyApiClient", client =>
{
    client.BaseAddress = new Uri("localhost:5003");
    
});

builder.Services.AddDbContext<JukeBoxContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DbConn")));

builder.Services.AddDbContext<AuthContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("UserDbConnection")));

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Auth/Login";
    });

builder.Services.AddDefaultIdentity<ApplicationUser>()
    .AddEntityFrameworkStores<AuthContext>();


builder.Services.Configure<IdentityOptions>(options =>
{
 
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = true;

});

builder.Services.AddControllersWithViews();

var app = builder.Build();

app.UseStaticFiles();

app.MapDefaultControllerRoute();

app.UseAuthentication();

app.UseAuthorization();

app.Run();
