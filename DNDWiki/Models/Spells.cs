using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace DNDWiki.Models
{
    public class Spells
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; } = "";
        [Range(0, 9)]
        public int Level { get; set; }
        public SpellSchool School { get; set; }
        public string Range { get; set; }
        public string Target { get; set; }

        public TimeDnd CastingTime { get; set; } = new TimeDnd();
        public TimeDnd Duration { get; set; } = new TimeDnd();

        // Komponenty
        public bool HasVerbalComponent { get; set; }
        public bool HasSomaticComponent { get; set; }
        public bool HasMaterialComponent { get; set; }

        public string MaterialList { get; set; }
        public List<DndClass> Classes { get; set; }
        public Source Source { get; set; }
    }
    public enum SpellSchool
    {
        Abjuration,
        Conjuration,
        Divination,
        Enchantment,
        Evocation,
        Illusion,
        Necromancy,
        Transmutation
    }

    [Owned]
    public class TimeDnd
    {
        public int Value { get; set; }
        public TimeScale Scale { get; set; }
        public override string ToString() => $"{Value} {Scale}";
    }

    public enum TimeScale
    {
        Instantaneous,
        Action,
        Minutes,
        Hours,
        Days
    }
}
