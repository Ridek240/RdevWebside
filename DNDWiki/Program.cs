using DNDWiki.Data;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Razor Pages
builder.Services.AddRazorPages();
builder.Services.AddDbContext<DNDDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DndConnection")));

// Authentication – tylko to
builder.Services.AddAuthentication("Identity.Application")
    .AddCookie("Identity.Application", options =>
    {
        options.Cookie.Name = "SharedIdentityCookie";
        options.Cookie.SecurePolicy = CookieSecurePolicy.None;
        options.Cookie.SameSite = SameSiteMode.Lax;
        options.Cookie.HttpOnly = false;
        options.Events.OnRedirectToLogin = context =>
        {
            var returnUrl = context.Request.Path + context.Request.QueryString;

            var redirectUrl =
                $"http://130.61.175.88:8080/Identity/Account/Login" +
                "?ReturnUrl=" + Uri.EscapeDataString("/DND" + returnUrl);

            context.Response.Redirect(redirectUrl);
            return Task.CompletedTask;
        };
    });

// Authorization
builder.Services.AddAuthorization();

// MUSI byæ identyczne jak w Main
builder.Services.AddDataProtection()
    .SetApplicationName("SharedAuthApp").PersistKeysToFileSystem(new DirectoryInfo("/keys")); 

var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    // Identity DbContext
    var identityDb = services.GetRequiredService<DNDDbContext>();
    identityDb.Database.Migrate();
}
    if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseForwardedHeaders();
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

app.Run();