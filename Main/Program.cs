using IndentityShared.Data;
using IndentityShared.Models;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;


///
/// Main Side Program
///
var builder = WebApplication.CreateBuilder(args);

// DB
builder.Services.AddDbContext<IdentityDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("IdentityConnection")));

// Identity
builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<IdentityDbContext>()
    .AddDefaultTokenProviders();

// Cookie
builder.Services.ConfigureApplicationCookie(options =>
{
    options.Cookie.Name = "SharedIdentityCookie";
    options.LoginPath = "/Identity/Account/Login";
    options.LogoutPath = "/Identity/Account/Logout";
    options.Cookie.HttpOnly = false;
    options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
    options.Cookie.SameSite = SameSiteMode.Lax;
});

// Razor
builder.Services.AddRazorPages();

// DataProtection
builder.Services.AddDataProtection()
    .SetApplicationName("SharedAuthApp");

// YARP
builder.Services.AddReverseProxy()
    .LoadFromMemory(
        new[]
        {
            new Yarp.ReverseProxy.Configuration.RouteConfig
            {
                RouteId = "moduleRoute",
                ClusterId = "moduleCluster",
                Match = new() { Path = "/DND/{**catch-all}" },
                Transforms = new List<Dictionary<string, string>>
                {
                    new() { { "PathRemovePrefix", "/DND" } }
                }
            }
        },
        new[]
        {
            new Yarp.ReverseProxy.Configuration.ClusterConfig
            {
                ClusterId = "moduleCluster",
                Destinations = new Dictionary<string, Yarp.ReverseProxy.Configuration.DestinationConfig>
                {
                    { "destination1", new() { Address = "https://localhost:5003/" } }
                }
            }
        });

var app = builder.Build();

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();


app.MapReverseProxy();

app.Run();