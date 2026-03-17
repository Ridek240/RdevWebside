using IndentityShared.Data;
using IndentityShared.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


// baza danych Identity
builder.Services.AddDbContext<IdentityDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("IdentityConnection")));

// Identity
builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<IdentityDbContext>()
    .AddDefaultTokenProviders();



builder.Services.AddRazorPages();

// Cookie wspólne z Module
builder.Services.ConfigureApplicationCookie(options =>
{
    options.Cookie.Name = "SharedIdentityCookie";  // obie strony u¿ywaj¹ tej samej cookie
    options.LoginPath = "/Account/Login";
    options.LogoutPath = "/Account/Logout";
});

var app = builder.Build();

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
// Main Pages
app.MapRazorPages();

// Wszystko pod /module trafia do Module
app.Map("/DND", moduleApp =>
{
    moduleApp.Run(async context =>
    {
        using var client = new HttpClient();
        // tutaj zak³adamy, ¿e Module dzia³a na https://localhost:5003
        var url = "https://localhost:5003" + context.Request.Path + context.Request.QueryString;

        var resp = await client.GetAsync(url);
        var content = await resp.Content.ReadAsStringAsync();
        await context.Response.WriteAsync(content);
    });
});

app.Run();