using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Main.Pages.Administration
{
    [Authorize(Roles = "Admin")]
    public class AdminPageModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
