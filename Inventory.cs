using System.Collections.Generic;
using System.Net.ServerSentEvents;

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
        public bool AddItem(Item item) 
        { 
            {
            //Check weight capacity
            if (currentWeight + item.Weight > capacity)
            {
                Console.WriteLine($"Cannot add {item.Name}: Exceeds weight capacity!");
                return false;
            }

            items.Add(item);
            currentWeight += item.Weight;
            Console.WriteLine($"Added {item.Name} to inventory.");
            return true;
            }
        }
        public bool RemoveItem(int id)
        {
            Item itemToRemove = items.Find(item => item.Id == id);

            if (itemToRemove != null)
            {
                items.Remove(itemToRemove);
                currentWeight -= itemToRemove.Weight;
                Console.WriteLine($"Removed {itemToRemove.Name} from inventory.");
                return true;
            }

            Console.WriteLine($"Item with ID {id} not founf.");
            return false;
        }
        public Item FindItem(int id)
        {
            return items.Find(item => item.Id == id);
        }

        public Item FindItemByName(string name)
        {
            return items.Find(items => item.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        }

        public List<Item> GetAllItems()
        {
            return new List<Item>(items); //return Copy
        }

        public void DisplayAllItems()
        {
            if (items.Count == 0)
            {
                Console.WriteLine("Inventory is empty.");
                return;
            }

            Console.WriteLine($"\n=== Inventory ({items.Count}/{capacity}kg) ===");
            foreach (var item in items)
            {
                Console.WriteLine($"-{item}");
            }
            Console.WriteLine($"Total Weight: {currentWeight}/{capacity}kg");
            Console.WriteLine($"Total Value: {CalculatedTotalValue()}g");
        }

        private int CalculatedTotalValue()
        {
            int total = 0;
            foreach (var item in items)
                total += item.Value;
            return total;
        }
    }
}