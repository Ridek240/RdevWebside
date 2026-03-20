using DNDWiki.Data;
using DNDWiki.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace DNDWiki.Pages.Spell
{
    public class DetailsModel : PageModel
    {
        private readonly DNDDbContext _context;
        public DetailsModel(DNDDbContext context) => _context = context;

        [BindProperty(SupportsGet = true)]
        public int Id { get; set; }  // ID klasy do edycji
        [BindProperty]
        public Spells Item { get; set; }
        public void OnGet()
        {
            Item = _context.Spells.Include(x =>x.CastingTime).Include(x=>x.Classes)
            .Where(c => c.Id == Id)
            .FirstOrDefault();
        }
    }
}
