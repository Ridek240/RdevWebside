using DNDWiki.Data;
using DNDWiki.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace DNDWiki.Pages.Species
{
    public class SpeciesDetailsModel : PageModel
    {
        private readonly DNDDbContext _context;
        public SpeciesDetailsModel(DNDDbContext context) => _context = context;

        [BindProperty(SupportsGet = true)]
        public int Id { get; set; }  // ID klasy do edycji
        [BindProperty]
        public Models.Species Specie { get; set; }
        public void OnGet()
        {
            Specie = _context.Species.Include(x=> x.CreatureSizes).Include(x => x.CreatureTypes)
            .Where(c => c.Id == Id)
            .FirstOrDefault();
        }
    }
}
