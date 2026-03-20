using DNDWiki.Data;
using DNDWiki.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DNDWiki.Pages.Spell
{
    public class IndexModel : PageModel
    {
        public class SpellModel
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public int Level {  get; set; }
            public SpellSchool School { get; set; }
            public string Source { get; set; }
        }
        public readonly DNDDbContext dndContext;

        public List<SpellModel> Spells { get; set; }
        public IndexModel(DNDDbContext dndContext)
        {
            this.dndContext = dndContext;
        }
        public void OnGet()
        {
            Spells = dndContext.Spells.Select(x => new SpellModel {Id =x.Id, Name = x.Name, School = x.School, Source = x.Source.Name }).ToList();
        }
    }
}
