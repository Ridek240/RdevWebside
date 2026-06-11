using Main.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Main.Pages.Games
{
    public class GoreberekModel : PageModel,IGameInterface
    {
        public string? Title => "Goreberek";

        public string? Image => "https://img.itch.zone/aW1hZ2UvMzY5OTU4My8yMjAxNjgyNy5wbmc=/original/hHJpCP.png";

        public void OnGet()
        {
        }
    }
}
