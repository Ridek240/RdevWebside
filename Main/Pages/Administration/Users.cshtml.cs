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
    public class UsersModel : PageModel
    {
        public readonly UserManager<ApplicationUser> _userManager;
        public readonly RoleManager<IdentityRole> _roleManager;
        public readonly IdentityDbContext dbContext;

        public UsersModel(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, IdentityDbContext dbContext)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            this.dbContext = dbContext;
        }

        public List<ApplicationUser> Users { get; set; } = new();
        public List<string> Roles { get; set; } = new();

        public async Task OnGetAsync()
        {
            Users = await dbContext.Users
            .Include(u => u.InviteToken).OrderBy(x => x.InviteToken).ThenBy(x => x.UserName) 
            .ToListAsync();
            Roles = new List<string>();
            foreach (var role in _roleManager.Roles)
            {
                Roles.Add(role.Name);
            }
        }

        public async Task<IActionResult> OnPostAddRoleAsync(string userId, string roleName)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user != null && !await _userManager.IsInRoleAsync(user, roleName))
            {
                await _userManager.AddToRoleAsync(user, roleName);
            }
            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostRemoveRoleAsync(string userId, string roleName)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user != null && await _userManager.IsInRoleAsync(user, roleName))
            {
                await _userManager.RemoveFromRoleAsync(user, roleName);
            }
            return RedirectToPage();
        }
    }
}
