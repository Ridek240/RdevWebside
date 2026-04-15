using Microsoft.EntityFrameworkCore;

namespace DNDWiki.Models
{
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string Description { get; set; } = "";
        public float? Weight { get; set; }
        public Money? Price { get; set; } = null;
        public ItemType? Type { get; set; } = null;
        public Source? Source { get; set; } = null;
    }

    public class Weapon : Item
    {
        public ItemType WeaponType { get; set; }
        public string Damage { get; set; }
        public List<ItemFeatures> Properties {  get; set; }
    }

    public class ItemTool : Item
    {
        public List<ItemFeatures> Properties { get; set; } = new();
    }

    [Owned]
    public class Money
    {
        public int CopperPieces { get; set; }
        public int SilverPieces { get; set; }
        public int GoldPieces { get; set; }
        public int PlatiniumPieces { get; set; }

        public override string ToString()
        {
            List<string> array = new();
            if(CopperPieces!=0)
            {
                array.Add($"{CopperPieces} CP");
            }
            if (SilverPieces != 0)
            {
                array.Add($"{SilverPieces} SP");
            }
            if (GoldPieces != 0)
            {
                array.Add($"{GoldPieces} GP");
            }
            if (PlatiniumPieces != 0)
            {
                array.Add($"{PlatiniumPieces} PP");
            }

            return string.Join(" ", array);
        }
    }

    public class ItemFeatures
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        public string Description { get; set; }
    }
    
    public class  ItemType
    {
        public int Id { get; set; }
        public string Type { get; set; } = "";
    }
    
}
