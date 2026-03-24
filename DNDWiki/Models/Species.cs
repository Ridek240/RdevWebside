using Microsoft.EntityFrameworkCore;

namespace DNDWiki.Models
{
    public class Species
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Speed { get; set; } = 30;
        public string? TypicalSize { get; set; }
        public string? TypicalWeight { get; set; }
        public List<CreatureType> CreatureTypes { get; set; }
        public List<CreatureSize> CreatureSizes { get; set; }
        public List<CreatureTraits> Traits { get; set; }
        //public List<Lineage> Lineages { get; set; }
        public Source Source { get; set; }
    }
    [Owned]
    public class CreatureTraits
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int? Level { get; set; }
    }
    public class Lineage
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<CreatureTraits> Traits { get; set; }
        public Source Source { get; set; }
    }
}
