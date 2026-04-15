using System.Drawing;

namespace DNDWiki.Models
{
    public class DndClass
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Dice HitPointDie { get; set; }
        public List<ClassFeature> ClassFeatures { get; set; }
        public List<Ability> SavingThrowProficiencies { get; set; }
        public List<Skill> SkillProficiencies { get; set; }
        public List<ItemTool> ToolsProficiencies { get; set; }
        public List<WeaponType> WeaponsProficiencies { get; set; }
        public List<ArmorTraining> ArmorProficiencies { get; set; }
        public Source Source { get; set; }
    }

    public class ClassFeature
    {
        public int Id { get; set; }
        public int Level { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

    }


}
