using DNDWiki.Data;
using DNDWiki.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace DNDWiki.Pages.Class
{
    public class ClassDetailModel : PageModel
    {
        private readonly DNDDbContext _context;
        public ClassDetailModel(DNDDbContext context) => _context = context;

        [BindProperty(SupportsGet = true)]
        public int ClassId { get; set; }  // ID klasy do edycji
        [BindProperty]
        public DndClass ClassItem { get; set; }
        public void OnGet()
        {
            ClassItem = _context.DndClasses.Include(x => x.ToolsProficiencies)
                .Include(x => x.SkillProficiencies).Include(x => x.SavingThrowProficiencies).Include(x => x.ClassFeatures)
                .Include(x => x.Source).Include(x => x.ArmorProficiencies).Include(x => x.WeaponsProficiencies)
            .Where(c => c.Id == ClassId)
            .FirstOrDefault();
        }
    }
}
