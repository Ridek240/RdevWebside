using DNDWiki.Data;
using DNDWiki.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace DNDWiki.Pages.Species
{
    public class AddSpeciesModel : PageModel
    {
        public class CreatureSizeInputModel
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public bool Selected { get; set; }
        }
        public class CreatureTypeModel
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public bool Selected { get; set; }
        }

        public class SpeciesInputModel
        {
            [Required]
            public string Name { get; set; }

            [Required]
            public string Description { get; set; }

            [Required]
            public string SourceId { get; set; }
            public int Speed { get; set; }
            public Dice HitDie { get; set; }

            public List<CreatureTraits> CreatureTraits { get; set; } = new();
            public List<CreatureSizeInputModel> CreatureSizes { get; set; } = new();
            public List<CreatureTypeModel> CreatureType { get; set; } = new();
        }


        [BindProperty]
        public SpeciesInputModel Input { get; set; } = new();

        public List<Source> Sources { get; set; } = new();

        private readonly DNDDbContext _context;

        public AddSpeciesModel(DNDDbContext context)
        {
            _context = context;
        }

        public void OnGet()
        {
            Sources = _context.Sources.ToList();
            Input.CreatureSizes = _context.CreatureSizes
                .Select(t => new CreatureSizeInputModel { Id = t.Id, Name = t.Name, Selected = false })
                .ToList();
            Input.CreatureType = _context.CreatureTypes
                .Select(t => new CreatureTypeModel { Id = t.Id, Name = t.Name, Selected = false })
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
            var classFeatures = Input.CreatureTraits
                .Where(f => !string.IsNullOrWhiteSpace(f.Name) && !string.IsNullOrWhiteSpace(f.Description))
                .ToList();

            var creatureSize = _context.CreatureSizes.AsEnumerable()
                    .Where(a => Input.CreatureSizes.Any(i => i.Id == a.Id && i.Selected))
                    .ToList();
            var creatureType = _context.CreatureTypes.AsEnumerable()
        .Where(a => Input.CreatureType.Any(i => i.Id == a.Id && i.Selected))
        .ToList();


            var Specie = new Models.Species
            {
                Name = Input.Name,
                Description = Input.Description,
                Source = _context.Sources.FirstOrDefault(x => x.Id == Input.SourceId),
                Speed = Input.Speed,
                CreatureTypes = creatureType,
                CreatureSizes = creatureSize,
                Traits = classFeatures
            };


            _context.Species.Add(Specie);
            _context.SaveChanges();

            return Redirect("Index");
        }
    }
}
