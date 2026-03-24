using IndentityShared.Data;
using IndentityShared.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Main.Pages.Administration
{
    [Authorize(Roles = "Admin")]
    public class InvCodesModel : PageModel
    {

        public readonly UserManager<ApplicationUser> _userManager;
        public readonly RoleManager<IdentityRole> _roleManager;
        public readonly IdentityDbContext dbContext;

        public InvCodesModel(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, IdentityDbContext dbContext)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            this.dbContext = dbContext;
        }

        public List<TokenViewModel> TokenCounts { get; set; } = new();

        public class TokenViewModel
        {
            public int Id { get; set; }
            public string Token { get; set; } = string.Empty;
            public int UserCount { get; set; }
            public bool IsEnabled { get; set; }
        }
        public void OnGet()
        {
            TokenCounts = dbContext.InviteTokens
                .Select(t => new TokenViewModel
                {
                    Id = t.Id,
                    Token = t.Token,
                    UserCount = t.InvitedUsers.Count,
                    IsEnabled = t.IsEnabled
                })
                .ToList();
        }
        public async Task<IActionResult> OnPostToggleEnabledAsync(int id)
        {
            var token = await dbContext.InviteTokens
                .Include(t => t.InvitedUsers) // za³aduj powi¹zanych u¿ytkowników
                .FirstOrDefaultAsync(t => t.Id == id);

            if (token == null)
                return NotFound();

            // Odwracamy stan tokena
            token.IsEnabled = !token.IsEnabled;

            foreach (var user in token.InvitedUsers)
            {
                user.LockoutEnabled = true; // zawsze w³¹czamy mo¿liwoœæ blokady
                if (!token.IsEnabled)
                {
                    user.LockoutEnd = DateTimeOffset.MaxValue;
                }
                else
                {
                    user.LockoutEnd = null;
                }
                await _userManager.UpdateSecurityStampAsync(user);
            }

            await dbContext.SaveChangesAsync();

            return new JsonResult(new
            {
                token.Id,
                token.IsEnabled
            });
        }

    
        public async Task<IActionResult> OnPostAddRandomTokenAsync()
        {
            // Generujemy losowy 20-znakowy token
            var token = new InviteToken
            {
                Token = GenerateRandomToken(20),
                IsEnabled = true
            };

            dbContext.InviteTokens.Add(token);
            await dbContext.SaveChangesAsync();

            return new JsonResult(new
            {
                token.Id,
                token.Token,
                token.IsEnabled
            });
        }

        private string GenerateRandomToken(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var random = new Random();
            return new string(Enumerable.Range(0, length)
                .Select(_ => chars[random.Next(chars.Length)]).ToArray());
        }
    }
}
