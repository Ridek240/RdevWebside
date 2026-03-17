using Microsoft.EntityFrameworkCore;
using IndentityShared.Data;
using IndentityShared.Models;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<IdentityDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("IdentityConnection")));


// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddControllers();

// Dodaj Authentication z tym samym schematem co Main
builder.Services.AddAuthentication("Identity.Application") // <- schemat Identity z Main
    .AddCookie("Identity.Application");

var app = builder.Build();

// Module u¿ywa tego samego cookie co Main
/*builder.Services.ConfigureApplicationCookie(options =>
{
    options.Cookie.Name = "SharedIdentityCookie";
});*/

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

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();
app.MapControllers();

app.Run();
