using System.ComponentModel.DataAnnotations;

namespace DNDWiki.Models
{
    public enum Dice
    {
        D4,
        D6,
        D8,
        D10,
        D12,
        D20,
        D100
    }


    public class Skill
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public int AbilityId { get; set; }
        public Ability Ability { get; set; }
    }

    public class Ability
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }


    public class ArmorTraining
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }

    public class WeaponType
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }



    public class CreatureType
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }

    public class CreatureSize
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }

}
