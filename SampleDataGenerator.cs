using System;

namespace mySampleDataGenerator
{
    public class ItemGenerator
    {
        private static int nextId = 1;
        public static Item CreateSword()
        {
            return new Item(nextId++, "Iron Sword", itemType.Weapon, 150, 3.5f)
            {Description ="A sturdy iron sword for combat."};
        }

        public static Item CreateHealthPotion()
        {
            return new Item(nextId++, "Health Potion", itemType.Potion, 50, 0.3f)
            {Description ="Restprs 50 health points."};
        }

        public static Item CreateLeatherArmor()
        {
            return new Item(nextId++,"Leather Armor", itemType.Armor, 200, 8.0f)
            {DescriptionAttribute = "Light armor made from tanned leather."};
        }
    }
}