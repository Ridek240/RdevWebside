using DNDWiki.Models;
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
        public DbSet<Item> Items { get; set; }
        public DbSet<Spells> Spells { get; set; }
        public DbSet<CreatureType> CreatureTypes { get; set; }
        public DbSet<CreatureSize> CreatureSizes { get; set; }
        public DbSet<ItemType> ItemTypes { get; set; }
        public DbSet<Species> Species { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Item>()
                .HasDiscriminator<string>("Item")
                .HasValue<Weapon>("Weapon")
                .HasValue<ItemTool>("Tool");


            modelBuilder.Entity<DndClass>()
    .HasMany(c => c.SavingThrowProficiencies)
    .WithMany();

            modelBuilder.Entity<DndClass>()
                .HasMany(c => c.SkillProficiencies)
                .WithMany();

            modelBuilder.Entity<DndClass>()
                .HasMany(c => c.ToolsProficiencies)
                .WithMany();

            modelBuilder.Entity<DndClass>()
                .HasMany(c => c.WeaponsProficiencies)
                .WithMany();

            modelBuilder.Entity<DndClass>()
                .HasMany(c => c.ArmorProficiencies)
                .WithMany();
            modelBuilder.Entity<Species>()
    .HasMany(c => c.CreatureTypes)
    .WithMany();
            modelBuilder.Entity<Species>()
    .HasMany(c => c.CreatureSizes)
    .WithMany();

            modelBuilder.Entity<Spells>().HasMany(c => c.Classes).WithMany();

            SeedData.Initiate(modelBuilder);
        }


    }

}

