using DNDWiki.Data;
using DNDWiki.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace DNDWiki.Pages.Class
{
    [Authorize]
    public class AddClassModel : PageModel
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
            public int AbilityId { get; set; }
            public string AbilityName { get; set; }
            public bool Selected { get; set; }
        }

        public class ToolInputModel
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string ItemType { get; set; }
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

        public AddClassModel(DNDDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ClassInputModel Input { get; set; } = new();

        public List<Source> Sources { get; set; } = new();

        public void OnGet()
        {
            Sources = _context.Sources.ToList();


            Input.ToolsProficiencies = _context.Items.OfType<ItemTool>().Include(x => x.Type)
                 .Select(t => new ToolInputModel { Id = t.Id, Name = t.Name, ItemType = t.Type.Type, Selected = false })
                 .ToList();
            Input.SkillProficiencies = _context.Skills.Include(x => x.Ability)
                .Select(s => new SkillInputModel { Id = s.Id, Name = s.Name, AbilityId = s.AbilityId, AbilityName = s.Ability.Name, Selected = false })
                .ToList();
            Input.SavingThrowProficiencies = _context.Abilities
                .Select(a => new AbilityInputModel { Id = a.Id, Name = a.Name, Selected = false })
                .ToList();
            Input.WeaponProficiency = _context.WeaponTypes
                .Select(a => new WeaponProficiencyInputModel { Id = a.Id, Name = a.Name, Selected = false })
                .ToList();
            Input.ArmorTraining = _context.ArmorTrainings
                .Select(a => new ArmorInputModel { Id = a.Id, Name = a.Name, Selected = false })
                .ToList();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                Sources = _context.Sources.ToList();
                return Page();
            }

            // Filtrujemy tylko wype³nione cechy
            var classFeatures = Input.ClassFeatures
                .Where(f => !string.IsNullOrWhiteSpace(f.Name) && !string.IsNullOrWhiteSpace(f.Description))
                .ToList();

            var SavingThrowProficiencies = _context.Abilities.AsEnumerable()
                .Where(a => Input.SavingThrowProficiencies.Any(i => i.Id == a.Id && i.Selected))
                .ToList();
            var SkillProficiencies = _context.Skills.AsEnumerable()
                .Where(a => Input.SkillProficiencies.Any(i => i.Id == a.Id && i.Selected))
                .ToList();
            var ArmorTraining = _context.ArmorTrainings.AsEnumerable()
                .Where(a => Input.ArmorTraining.Any(i => i.Id == a.Id && i.Selected))
                .ToList();
            var WeaponProf = _context.WeaponTypes.AsEnumerable()
                .Where(a => Input.WeaponProficiency.Any(i => i.Id == a.Id && i.Selected))
                .ToList();
            var ToolsProficiencies = _context.Items.OfType<ItemTool>().AsEnumerable()
                .Where(a => Input.ToolsProficiencies.Any(i => i.Id == a.Id && i.Selected))
                .ToList();
            var newClass = new DndClass
            {
                Name = Input.Name,
                Description = Input.Description,
                Source = _context.Sources.FirstOrDefault(x => x.Id == Input.SourceId),
                SavingThrowProficiencies = SavingThrowProficiencies,
                SkillProficiencies = SkillProficiencies,
                ToolsProficiencies = ToolsProficiencies,
                WeaponsProficiencies = WeaponProf,
                ArmorProficiencies = ArmorTraining,
                HitPointDie = Input.HitDie,
                ClassFeatures = classFeatures
            };

            _context.DndClasses.Add(newClass);
            _context.SaveChanges();

            return Redirect("Index");
        }
    }
}