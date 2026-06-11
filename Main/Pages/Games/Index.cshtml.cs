using Main.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Reflection;

namespace Main.Pages.Games
{
    public class IndexModel : PageModel
    {
        public List<(string Title, string Url, string Image)> Pages { get; set; } = new();

        public void OnGet()
        {
            Pages = Assembly.GetExecutingAssembly()
                .GetTypes()
                .Where(t => typeof(IGameInterface).IsAssignableFrom(t)
                            && !t.IsInterface
                            && !t.IsAbstract)
                .Select(t =>
                {
                    var instance = Activator.CreateInstance(t) as IGameInterface;

                    return new
                    {
                        Title = instance?.Title,
                        Url = "/Games/" + t.Name.Replace("Model", ""),
                        Image = instance?.Image,
                    };
                })
                .Where(x => !string.IsNullOrWhiteSpace(x.Title))
                .Select(x => (x.Title!, x.Url, x.Image))
                .ToList();
        }
    }
}
