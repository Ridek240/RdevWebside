using DNDWiki.Data;
using DNDWiki.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace DNDWiki.Pages.Items
{
    public class AddItemModel : PageModel
    {
        public class InputModel
        {
            [Required]
            public string Name { get; set; }
            [Required]
            public string Description { get; set; }
            [Required]
            public string SourceId { get; set; }
            [Required]
            public string ItemTypeId { get; set; }
            public Money Price { get; set; } = new();
            public float? Weight { get; set; }
            
        }

        private readonly DNDDbContext _context;

        public AddItemModel(DNDDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public InputModel Input { get; set; } = new();

        public List<Source> Sources { get; set; } = new();
        public List<ItemType> ItemTypes { get; set; } = new();
        public void OnGet()
        {
            Sources = _context.Sources.ToList();
            ItemTypes = _context.ItemTypes.ToList();

        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                Sources = _context.Sources.ToList();
                return Page();
            }
            var item = new Item
            {
                Name = Input.Name,
                Description = Input.Description,
                Price = Input.Price,
                Source = _context.Sources.FirstOrDefault(x => x.Id == Input.SourceId),
            };

            _context.Items.Add(item);
            _context.SaveChanges();
            return Redirect("Index");
        }

        
        }
}
