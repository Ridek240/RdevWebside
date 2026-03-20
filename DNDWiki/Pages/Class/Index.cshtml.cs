using DNDWiki.Data;
using DNDWiki.Models;
using IndentityShared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DNDWiki.Pages.Class
{
    public class IndexModel : PageModel
    {
        private readonly DNDDbContext dndContext;

        //properties

        //public List<>


        public class ClassSource
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Source { get; set; }
        }
        public List<ClassSource> Classes { get; set; }

        public IndexModel(DNDDbContext dndContext)
        {
            this.dndContext = dndContext;
        }
        public void OnGet()
        {
            Classes = dndContext.DndClasses
                .Select(x => new ClassSource
                {
                    Id = x.Id,
                    Name = x.Name,
                    Source = x.Source.Name
                })
                .ToList();
        }
    }
}
