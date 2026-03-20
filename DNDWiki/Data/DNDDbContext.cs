using DNDWiki.Models;
using IndentityShared.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DNDWiki.Data
{
    public class DNDDbContext : DbContext
    {
        public DNDDbContext(DbContextOptions<DNDDbContext> options) : base(options)
        { }
        public DbSet<Source> Sources { get; set; }
        public DbSet<DndClass> DndClasses { get; set; }

        public DbSet<Skill> Skills { get; set; }
        public DbSet<Ability> Abilities { get; set; }
        public DbSet<ArmorTraining> ArmorTrainings { get; set; }
        public DbSet<WeaponType> WeaponTypes { get; set; }
        public DbSet<ToolType> ToolTypes { get; set; }
        public DbSet<Spells> Spells { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Source>().HasData(
            new Source { Id = "PHB24", Name = "Players Handbook 2024" });

            // Seed Abilities
            modelBuilder.Entity<Ability>().HasData(
                new Ability { Id = 1, Name = "Strength" },
                new Ability { Id = 2, Name = "Dexterity" },
                new Ability { Id = 3, Name = "Constitution" },
                new Ability { Id = 4, Name = "Intelligence" },
                new Ability { Id = 5, Name = "Wisdom" },
                new Ability { Id = 6, Name = "Charisma" }
            );

            // Seed Skills
            modelBuilder.Entity<Skill>().HasData(
                new Skill { Id = 1, Name = "Athletics", AbilityId = 1 },

                new Skill { Id = 2, Name = "Acrobatics", AbilityId = 2 },
                new Skill { Id = 3, Name = "SleightOfHand", AbilityId = 2 },
                new Skill { Id = 4, Name = "Stealth", AbilityId = 2 },

                new Skill { Id = 5, Name = "Arcana", AbilityId = 4 },
                new Skill { Id = 6, Name = "History", AbilityId = 4 },
                new Skill { Id = 7, Name = "Investigation", AbilityId = 4 },
                new Skill { Id = 8, Name = "Nature", AbilityId = 4 },
                new Skill { Id = 9, Name = "Religion", AbilityId = 4 },

                new Skill { Id = 10, Name = "AnimalHandling", AbilityId = 5 },
                new Skill { Id = 11, Name = "Insight", AbilityId = 5 },
                new Skill { Id = 12, Name = "Medicine", AbilityId = 5 },
                new Skill { Id = 13, Name = "Perception", AbilityId = 5 },
                new Skill { Id = 14, Name = "Survival", AbilityId = 5 },

                new Skill { Id = 15, Name = "Deception", AbilityId = 6 },
                new Skill { Id = 16, Name = "Intimidation", AbilityId = 6 },
                new Skill { Id = 17, Name = "Performance", AbilityId = 6 },
                new Skill { Id = 18, Name = "Persuasion", AbilityId = 6 }
            );


            // Seed ArmorTraining
            modelBuilder.Entity<ArmorTraining>().HasData(
                new ArmorTraining { Id = 1, Name = "Light" },
                new ArmorTraining { Id = 2, Name = "Medium" },
                new ArmorTraining { Id = 3, Name = "Heavy" },
                new ArmorTraining { Id = 4, Name = "Shields" }
            );

            // Seed WeaponTypes
            modelBuilder.Entity<WeaponType>().HasData(
                new WeaponType { Id = 1, Name = "Simple" },
                new WeaponType { Id = 2, Name = "Martial" }
            );

            // Seed ToolTypes
            modelBuilder.Entity<ToolType>().HasData(
                new ToolType { Id = 1, Name = "AlchemistSupplies" },
                new ToolType { Id = 2, Name = "BrewersSupplies" },
                new ToolType { Id = 3, Name = "CalligraphersSupplies" },
                new ToolType { Id = 4, Name = "CarpentersTools" },
                new ToolType { Id = 5, Name = "CartographersTools" },
                new ToolType { Id = 6, Name = "CobblersTools" },
                new ToolType { Id = 7, Name = "CooksUtensils" },
                new ToolType { Id = 8, Name = "GlassblowersTools" },
                new ToolType { Id = 9, Name = "JewelersTools" },
                new ToolType { Id = 10, Name = "LeatherworkersTools" },
                new ToolType { Id = 11, Name = "MasonsTools" },
                new ToolType { Id = 12, Name = "PaintersSupplies" },
                new ToolType { Id = 13, Name = "PottersTools" },
                new ToolType { Id = 14, Name = "SmithsTools" },
                new ToolType { Id = 15, Name = "TinkersTools" },
                new ToolType { Id = 16, Name = "WeaversTools" },
                new ToolType { Id = 17, Name = "WoodcarversTools" },
                new ToolType { Id = 18, Name = "Bagpipes" },
                new ToolType { Id = 19, Name = "Drum" },
                new ToolType { Id = 20, Name = "Dulcimer" },
                new ToolType { Id = 21, Name = "Flute" },
                new ToolType { Id = 22, Name = "Lute" },
                new ToolType { Id = 23, Name = "Lyre" },
                new ToolType { Id = 24, Name = "Horn" },
                new ToolType { Id = 25, Name = "PanFlute" },
                new ToolType { Id = 26, Name = "Shawm" },
                new ToolType { Id = 27, Name = "Viol" },
                new ToolType { Id = 28, Name = "DisguiseKit" },
                new ToolType { Id = 29, Name = "ForgeryKit" },
                new ToolType { Id = 30, Name = "HerbalismKit" },
                new ToolType { Id = 31, Name = "NavigatorsTools" },
                new ToolType { Id = 32, Name = "PoisonersKit" },
                new ToolType { Id = 33, Name = "ThievesTools" }
            );
        }
    }

}

