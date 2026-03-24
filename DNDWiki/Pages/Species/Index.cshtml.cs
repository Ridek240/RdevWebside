using DNDWiki.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DNDWiki.Pages.Species
{
    public class IndexModel : PageModel
    {
        private readonly DNDDbContext dndContext;

        public class SpeciesSource
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Source { get; set; }
        }
        public List<SpeciesSource> Species { get; set; }

        public IndexModel(DNDDbContext dndContext)
        {
            this.dndContext = dndContext;
        }
        public void OnGet()
        {
            Species = dndContext.Species
                .Select(x => new SpeciesSource
                {
                    Id = x.Id,
                    Name = x.Name,
                    Source = x.Source.Name
                })
                .ToList();
        }
    }
}

