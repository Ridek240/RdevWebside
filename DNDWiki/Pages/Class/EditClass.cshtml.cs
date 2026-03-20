using DNDWiki.Data;
using DNDWiki.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace DNDWiki.Pages.Class
{
    public class EditClassModel : PageModel
    {
        #region InputModels
        public class AbilityInputModel
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public bool Selected { get; set; }
        }

        public class SkillInputModel
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public bool Selected { get; set; }
        }

        public class ToolInputModel
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public bool Selected { get; set; }
        }
        public class WeaponProficiencyInputModel
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public bool Selected { get; set; }
        }
        public class ArmorInputModel
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public bool Selected { get; set; }
        }

        public class ClassInputModel
        {
            [Required]
            public string Name { get; set; }

            [Required]
            public string Description { get; set; }

            [Required]
            public string SourceId { get; set; }

            public Dice HitDie { get; set; }

            public List<AbilityInputModel> SavingThrowProficiencies { get; set; } = new();
            public List<SkillInputModel> SkillProficiencies { get; set; } = new();
            public List<ToolInputModel> ToolsProficiencies { get; set; } = new();
            public List<ClassFeature> ClassFeatures { get; set; } = new();
            public List<WeaponProficiencyInputModel> WeaponProficiency { get; set; } = new();
            public List<ArmorInputModel> ArmorTraining { get; set; } = new();
        }
        #endregion

        private readonly DNDDbContext _context;
        public EditClassModel(DNDDbContext context) => _context = context;

        [BindProperty]
        public ClassInputModel Input { get; set; } = new();

        public List<Source> Sources { get; set; } = new();

        [BindProperty(SupportsGet = true)]
        public int ClassId { get; set; }  // ID klasy do edycji

        public IActionResult OnGet()
        {

            Sources = _context.Sources.ToList();

            var existingClass = _context.DndClasses.Include(x => x.ToolsProficiencies).Include(x => x.SkillProficiencies).Include(x => x.SavingThrowProficiencies).Include(x => x.ClassFeatures)
                .Where(c => c.Id == ClassId)
                .FirstOrDefault();

            if (existingClass == null)
                return Redirect("Index");

            // Wype³niamy InputModel istniej¹cymi danymi
            Input.Name = existingClass.Name;
            Input.Description = existingClass.Description;
            Input.SourceId = existingClass.Source?.Id;
            Input.HitDie = existingClass.HitPointDie;

            Input.SkillProficiencies = _context.Skills
                .AsEnumerable()
                .Select(s => new SkillInputModel
                {
                    Id = s.Id,
                    Name = s.Name,
                    Selected = existingClass.SkillProficiencies.Any(sp => sp.Id == s.Id)
                })
                .ToList();

            Input.ToolsProficiencies = _context.ToolTypes
                .AsEnumerable()
                .Select(t => new ToolInputModel
                {
                    Id = t.Id,
                    Name = t.Name,
                    Selected = existingClass.ToolsProficiencies.Any(tp => tp.Id == t.Id)
                })
                .ToList();

            Input.SavingThrowProficiencies = _context.Abilities
                .AsEnumerable()
                .Select(a => new AbilityInputModel
                {
                    Id = a.Id,
                    Name = a.Name,
                    Selected = existingClass.SavingThrowProficiencies.Any(st => st.Id == a.Id)
                })
                .ToList();
            Input.WeaponProficiency = _context.WeaponTypes
                .AsEnumerable()
                .Select(a => new WeaponProficiencyInputModel
                {
                    Id = a.Id,
                    Name = a.Name,
                    Selected = existingClass.WeaponsProficiencies.Any(st => st.Id == a.Id)
                })
                .ToList();
            Input.ArmorTraining = _context.ArmorTrainings
                .AsEnumerable()
                .Select(a => new ArmorInputModel
                {
                    Id = a.Id,
                    Name = a.Name,
                    Selected = existingClass.ArmorProficiencies.Any(st => st.Id == a.Id)
                })
                .ToList();

            Input.ClassFeatures = existingClass.ClassFeatures;

            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                Sources = _context.Sources.ToList();
                return Page();
            }

            var existingClass = _context.DndClasses.Include(x => x.ToolsProficiencies).Include(x => x.SkillProficiencies).Include(x => x.SavingThrowProficiencies).Include(x => x.ClassFeatures)
                .Where(c => c.Id == ClassId)
                .FirstOrDefault();

            if (existingClass == null)
                return Redirect("Index");

            existingClass.Name = Input.Name;
            existingClass.Description = Input.Description;
            existingClass.Source = _context.Sources.FirstOrDefault(x => x.Id == Input.SourceId);

            existingClass.SkillProficiencies = _context.Skills
                .AsEnumerable()
                .Where(s => Input.SkillProficiencies.Any(i => i.Id == s.Id && i.Selected))
                .ToList();

            existingClass.ToolsProficiencies = _context.ToolTypes
                .AsEnumerable()
                .Where(t => Input.ToolsProficiencies.Any(i => i.Id == t.Id && i.Selected))
                .ToList();

            existingClass.SavingThrowProficiencies = _context.Abilities
                .AsEnumerable()
                .Where(a => Input.SavingThrowProficiencies.Any(i => i.Id == a.Id && i.Selected))
                .ToList();
            
            existingClass.ClassFeatures = Input.ClassFeatures
                .Where(f => !string.IsNullOrWhiteSpace(f.Name) && !string.IsNullOrWhiteSpace(f.Description))
                .ToList();
            existingClass.HitPointDie = Input.HitDie;
            _context.SaveChanges();

            return Redirect("Index");
        }
    }
}
