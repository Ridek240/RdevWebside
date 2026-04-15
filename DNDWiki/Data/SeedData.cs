using DNDWiki.Models;
using Microsoft.EntityFrameworkCore;

namespace DNDWiki.Data
{
    public class SeedData
    {
        public static void Initiate(ModelBuilder modelBuilder)
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


            modelBuilder.Entity<ItemType>().HasData(
                new ItemType { Id = 1, Type = "Simple Weapon" },
                new ItemType { Id = 2, Type = "Martial Weapon" },
                new ItemType { Id = 3, Type = "Light Armor" },
                new ItemType { Id = 4, Type = "Medium Armor" },
                new ItemType { Id = 5, Type = "Heavy Armor" },
                new ItemType { Id = 6, Type = "Shield" },
                new ItemType { Id = 7, Type = "Ammunition" },
                new ItemType { Id = 8, Type = "Tool" },
                new ItemType { Id = 9, Type = "Artisan Tool" },
                new ItemType { Id = 10, Type = "Gaming Set" },
                new ItemType { Id = 11, Type = "Musical Instrument" },
                new ItemType { Id = 12, Type = "Adventuring Gear" },
                new ItemType { Id = 13, Type = "Pack" },
                new ItemType { Id = 14, Type = "Container" },
                new ItemType { Id = 15, Type = "Gemstone" },
                new ItemType { Id = 16, Type = "Holy Symbol" },
                new ItemType { Id = 17, Type = "Arcane Focus" },
                new ItemType { Id = 18, Type = "Druidic Focus" },
                new ItemType { Id = 19, Type = "Poison" },
                new ItemType { Id = 20, Type = "Potion" }
            );

            // Seed ToolTypes
            modelBuilder.Entity<ItemTool>().HasData(
                new { Id = 1, Name = "Alchemist Supplies", Description = "",  TypeId = 9, SourceId = "PHB24" },
                new { Id = 2, Name = "Brewers Supplies", Description = "", TypeId = 9, SourceId = "PHB24" },
                new { Id = 3, Name = "Calligraphers Supplies", Description = "", TypeId = 9, SourceId = "PHB24" },
                new { Id = 4, Name = "Carpenters Tools", Description = "", TypeId = 9, SourceId = "PHB24" },
                new { Id = 5, Name = "Cartographers Tools", Description = "", TypeId = 9, SourceId = "PHB24" },
                new { Id = 6, Name = "Cobblers Tools", Description = "", TypeId = 9, SourceId = "PHB24" },
                new { Id = 7, Name = "Cooks Utensils", Description = "", TypeId = 9, SourceId = "PHB24" },
                new { Id = 8, Name = "Glassblowers Tools", Description = "", TypeId = 9, SourceId = "PHB24" },
                new { Id = 9, Name = "Jewelers Tools", Description = "", TypeId = 9, SourceId = "PHB24" },
                new { Id = 10, Name = "Leatherworkers Tools", Description = "", TypeId = 9, SourceId = "PHB24" },
                new { Id = 11, Name = "Masons Tools", Description = "", TypeId = 9, SourceId = "PHB24" },
                new { Id = 12, Name = "Painters Supplies", Description = "", TypeId = 9, SourceId = "PHB24" },
                new { Id = 13, Name = "Potters Tools", Description = "", TypeId = 9, SourceId = "PHB24" },
                new { Id = 14, Name = "Smiths Tools", Description = "", TypeId = 9, SourceId = "PHB24" },
                new { Id = 15, Name = "Tinkers Tools", Description = "", TypeId = 9, SourceId = "PHB24" },
                new { Id = 16, Name = "Weavers Tools", Description = "", TypeId = 9, SourceId = "PHB24" },
                new { Id = 17, Name = "Woodcarvers Tools", Description = "", TypeId = 9, SourceId = "PHB24" },

                new { Id = 18, Name = "Bagpipes", Description = "", TypeId = 11, SourceId = "PHB24" },
                new { Id = 19, Name = "Drum", Description = "", TypeId = 11, SourceId = "PHB24" },
                new { Id = 20, Name = "Dulcimer", Description = "", TypeId = 11, SourceId = "PHB24" },
                new { Id = 21, Name = "Flute", Description = "", TypeId = 11, SourceId = "PHB24" },
                new { Id = 22, Name = "Lute", Description = "", TypeId = 11, SourceId = "PHB24" },
                new { Id = 23, Name = "Lyre", Description = "", TypeId = 11, SourceId = "PHB24" },
                new { Id = 24, Name = "Horn", Description = "", TypeId = 11, SourceId = "PHB24" },
                new { Id = 25, Name = "PanFlute", Description = "", TypeId = 11, SourceId = "PHB24" },
                new { Id = 26, Name = "Shawm", Description = "", TypeId = 11, SourceId = "PHB24" },
                new { Id = 27, Name = "Viol", Description = "", TypeId = 11, SourceId = "PHB24" },

                new { Id = 28, Name = "Disguise Kit", Description = "", TypeId = 8, SourceId = "PHB24" },
                new { Id = 29, Name = "Forgery Kit", Description = "", TypeId = 8, SourceId = "PHB24" },
                new { Id = 30, Name = "Herbalism Kit", Description = "", TypeId = 8, SourceId = "PHB24" },
                new { Id = 31, Name = "Navigators Tools", Description = "", TypeId = 8, SourceId = "PHB24" },
                new { Id = 32, Name = "Poisoners Kit", Description = "", TypeId = 8, SourceId = "PHB24" },
                new { Id = 33, Name = "Thieves Tools", Description = "", TypeId = 8, SourceId = "PHB24" },

                new { Id = 34, Name = "Dice Set", Description = "", TypeId = 10, SourceId = "PHB24" },
                new { Id = 35, Name = "Dragonchess Set", Description = "", TypeId = 10, SourceId = "PHB24" },
                new { Id = 36, Name = "Playing Card Set", Description = "", TypeId = 10, SourceId = "PHB24" },
                new { Id = 37, Name = "Three Dragon Ante Set", Description = "", TypeId = 10, SourceId = "PHB24" }
            );



            //creatures
            modelBuilder.Entity<CreatureType>().HasData(
                new CreatureType { Id = 1, Name = "Aberration" },
                new CreatureType { Id = 2, Name = "Beast" },
                new CreatureType { Id = 3, Name = "Celestial" },
                new CreatureType { Id = 4, Name = "Construct" },
                new CreatureType { Id = 5, Name = "Dragon" },
                new CreatureType { Id = 6, Name = "Elemental" },
                new CreatureType { Id = 7, Name = "Fey" },
                new CreatureType { Id = 8, Name = "Fiend" },
                new CreatureType { Id = 9, Name = "Giant" },
                new CreatureType { Id = 10, Name = "Humanoid" },
                new CreatureType { Id = 11, Name = "Monstrosity" },
                new CreatureType { Id = 12, Name = "Ooze" },
                new CreatureType { Id = 13, Name = "Plant" },
                new CreatureType { Id = 14, Name = "Undead" }
            );
            modelBuilder.Entity<CreatureSize>().HasData(
                new CreatureSize { Id = 1, Name = "Tiny" },
                new CreatureSize { Id = 2, Name = "Small" },
                new CreatureSize { Id = 3, Name = "Medium" },
                new CreatureSize { Id = 4, Name = "Large" },
                new CreatureSize { Id = 5, Name = "Huge" },
                new CreatureSize { Id = 6, Name = "Gargantuan" }
            );
        }
    }
}
