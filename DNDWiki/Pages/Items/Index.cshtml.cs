using DNDWiki.Data;
using DNDWiki.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace DNDWiki.Pages.Items
{
    public class IndexModel : PageModel
    {
        private readonly DNDDbContext dndContext;

        public class ItemSource
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Cost { get; set; }
            public string Weight { get; set; }
            public string Source { get; set; }
        }
        public List<ItemSource> Items { get; set; }

        public IndexModel(DNDDbContext dndContext)
        {
            this.dndContext = dndContext;
        }
        public void OnGet()
        {
            Items = dndContext.Items.Include(x => x.Price).AsNoTracking()
                .Select(x => new ItemSource
                {
                    Id = x.Id,
                    Name = x.Name,
                    Source = x.Source != null ? x.Source.Name : "--",
                    Weight = x.Weight.HasValue ? $"{x.Weight} lbs." : "--",
                    Cost = x.Price != null ? x.Price.ToString() : "--"
                })
                .ToList();
        }
    }
}
