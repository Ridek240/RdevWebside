using DNDWiki.Data;
using DNDWiki.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace DNDWiki.Pages.Spell
{
    public class AddSpellModel : PageModel
    {
        public class SpellInputModel
        {
            [Required]
            public string Name { get; set; }

            public string Description { get; set; }
            public string Target { get; set; }
            public string Range { get; set; }

            [Range(0, 9)]
            public int Level { get; set; }

            public SpellSchool School { get; set; }

            public TimeDnd CastingTime { get; set; } = new();
            public TimeDnd Duration { get; set; } = new();

            public bool HasVerbalComponent { get; set; }
            public bool HasSomaticComponent { get; set; }
            public bool HasMaterialComponent { get; set; }

            public string MaterialList { get; set; }

            public string SourceId { get; set; }

            public List<ClassCheckbox> Classes { get; set; } = new();
        }

        public class ClassCheckbox
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public bool Selected { get; set; }
        }

        private readonly DNDDbContext _context;
        public List<Source> Sources { get; set; } = new();
        public AddSpellModel(DNDDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public SpellInputModel Input { get; set; } = new();
        public void OnGet()
        {
            Input.Classes = _context.DndClasses
    .Select(c => new ClassCheckbox
    {
        Id = c.Id,
        Name = c.Name,
        Selected = false
    }).ToList();

            Sources = _context.Sources.ToList();
        }

        public void OnPost()
        {
            var selectedClasses = _context.DndClasses.AsEnumerable()
    .Where(c => Input.Classes.Any(i => i.Id == c.Id && i.Selected))
    .ToList();

            var spell = new Spells
            {
                Name = Input.Name,
                Description = Input.Description,
                Level = Input.Level,
                School = Input.School,
                Range = Input.Range,
                Target = Input.Target,
                Duration = Input.Duration,
                CastingTime = Input.CastingTime,
                HasVerbalComponent = Input.HasVerbalComponent,
                HasSomaticComponent = Input.HasSomaticComponent,
                HasMaterialComponent = Input.HasMaterialComponent,
                MaterialList = Input.MaterialList ?? "",
                Classes = selectedClasses,
                Source = _context.Sources.FirstOrDefault(s => s.Id == Input.SourceId)
            };

            _context.Spells.Add(spell);
            _context.SaveChanges();
        }
    }
}
