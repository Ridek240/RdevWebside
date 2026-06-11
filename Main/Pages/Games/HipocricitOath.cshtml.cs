using Main.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Main.Pages.Games
{
    public class HipocricitOathModel : PageModel, IGameInterface
    {
        public string? Title => "Hipocratic Oath";

        public string? Image => "https://img.itch.zone/aW1nLzIyMDM1ODY1LnBuZw==/original/EWd0Rh.png";

        public void OnGet()
        {
        }
    }
}
