using IndentityShared.Data;
using IndentityShared.Models;
using Main.Areas.Identity.Services;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
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

builder.Services.Configure<SecurityStampValidatorOptions>(options =>
{
    options.ValidationInterval = TimeSpan.Zero;
});
// Cookie
builder.Services.ConfigureApplicationCookie(options =>
{
    options.Cookie.Name = "SharedIdentityCookie";
    options.LoginPath = "/Identity/Account/Login";
    options.LogoutPath = "/Identity/Account/Logout";
    options.Cookie.HttpOnly = false;
    options.Cookie.SecurePolicy = CookieSecurePolicy.None;
    options.Cookie.SameSite = SameSiteMode.Lax;
});

// Razor
builder.Services.AddRazorPages();

// DataProtection
builder.Services.AddDataProtection()
    .SetApplicationName("SharedAuthApp");
builder.Services.AddTransient<IEmailSender, EmailSender>();
// YARP
var moduleAddress = builder.Environment.IsDevelopment()
    ? "https://localhost:5003" // lokalnie modu³ uruchamiasz normalnie
    : "http://module/";         // w prod / w Docker Compose
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
                    { "destination1", new() { Address = moduleAddress } }
                }
            }
        });

var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    // Identity DbContext
    var identityDb = services.GetRequiredService<IdentityDbContext>();
    identityDb.Database.Migrate();

    var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
    var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();

    var roleExists = await roleManager.RoleExistsAsync("Admin");
    if (!roleExists)
    {
        await roleManager.CreateAsync(new IdentityRole("Admin"));
        await roleManager.CreateAsync(new IdentityRole("Developer"));
        await roleManager.CreateAsync(new IdentityRole("User"));
    }
    var AdminUser = await userManager.FindByNameAsync("Admin");
    if(AdminUser == null)
    {
        var user = new ApplicationUser
        {
            UserName = "Admin",
            Email = "admin@example.com",
            EmailConfirmed = true
        };

        // Tworzenie u¿ytkownika z has³em
        var result = await userManager.CreateAsync(user, "Admin1!");
        if (result.Succeeded)
        {
            // Mo¿esz tu dodaæ role, np. admin
            await userManager.AddToRoleAsync(user, "Admin");
        }
        else
        {
            foreach (var error in result.Errors)
            {
                Console.WriteLine(error.Description);
            }
        }
    }
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapReverseProxy();
app.MapRazorPages();


app.Run();