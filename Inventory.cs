using System.Collections.Generic;

namespace myInventorySystem
{
    public class Inventory
    {
        private List<Item> items;
        private int capacity;
        private float currentWeight;

        public Inventory(int capacity = 100)
        {
            items = new List<Item>();
            this.capacity = capacity;
            currentWeight = 0;
        }

        //Basic properties to implement
        public int ItemCount => items.Count;
        public float CurrentWeight => currentWeight;
        public int Capacity => capacity;

        //Placeholder methods
        public bool AddItem(Item item) { return false; }
        public bool RemoveItem(int id) { return false; }
        public Item FindItem(int id) { return null; }
    }
}