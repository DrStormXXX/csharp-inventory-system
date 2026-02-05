using System;

namespace myInventorySystem
{
    public enum ItemType{Weapon, Armor, Potion, Material, Quest}

    public class Item
    {
        //Properties
        public int Id { get; }
        public string Name { get; set; }
        public ItemType Type { get; set; }
        public int Value { get; set; }
        public float Weight { get; set; }
        public string Description { get; set; }

        //Constructor
        public Item(int id, string name, ItemType type, int value, float weight)
        {
            Id = id;
            Name = name;
            Type = type;
            Value = value;
            Weight = weight;
            Description = string.Empty;
        }

        //Methods
        public override string ToString()
        {
            return $"{Name} ({Type}) - Value: R{Value}, Weight: {Weight}kg";
        }

        public string GetDetailedInfo()
        {
            return $"ID: {Id}\nName: {Name}\nType: {Type}\nValue: R{Value}\nWeight: {Weight}kg\nDescription: {Description}";
        }
    }
}

