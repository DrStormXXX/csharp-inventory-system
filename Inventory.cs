using System.Collections.Generic;
using System.Linq;

namespace myInventorySystem
{
    public class Inventory
    {
        private List<Item> items;
        private int capacity;
        private float maxWeight;
        private float currentWeight;

        public Inventory(int capacity = 100, float maxWeight = 50.0f)
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

            //Checking limits
            if (items.Count >= capacity)  // Check item count
            {
                Console.WriteLine($"Cannot add {item.Name}: Inventory full!");
                return false;
            }
            
            if (currentWeight + item.Weight > maxWeight)
            {
                Console.WriteLine($"Cannot add {item.Name}: Exceeds maximum weight Limit!");
                return false;
            }


            items.Add(item);
            currentWeight += item.Weight;
            Console.WriteLine($"Added {item.Name} to inventory.");
            return true;
            
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

            Console.WriteLine($"Item with ID {id} not found.");
            return false;
        }
        public Item FindItem(int id)
        {
            return items.Find(item => item.Id == id);
        }

        public Item FindItemByName(string name)
        {
            return items.Find(item => item.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
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

            Console.WriteLine($"\n=== Inventory ({items.Count} items, {currentWeight}/{maxWeight}kg) ===");
            foreach (var item in items)
            {
                Console.WriteLine($"-{item}");
            }
            Console.WriteLine($"Total Weight: {currentWeight}/{maxWeight}kg");
            Console.WriteLine($"Total Value: R{CalculatedTotalValue()}");
        }

        private int CalculatedTotalValue()
        {
            int total = 0;
            foreach (var item in items)
                total += item.Value;
            return total;
        }
        public List<Item> SortByName(bool ascending = true)
        {
            var sorted = new List<Item>(items);
            sorted.Sort((a,b) => ascending ?
                a.Name.CompareTo(b.Name) :
                b.Name.CompareTo(a.Name));
            return sorted;
        }

        public List<Item> SortByValue(bool ascending = true)
        {
            var sorted = new List<Item>(items);
            sorted.Sort((a,b) => ascending ?
                a.Value.CompareTo(b.Value) :
                b.Value.CompareTo(a.Value));
                return sorted;
        }

        public List<Item> SortByWeight(bool ascending = true)
        {
            var sorted = new List<Item>(items);
            sorted.Sort((a,b) => ascending ?
                a.Weight.CompareTo(b.Weight) :
                b.Weight.CompareTo(a.Weight));
                return sorted;
        }

        //Using LINQ for more complex sorting
        public List<Item> SortByTypeThenName()
        {
            return items
                .OrderBy(item => item.Type)
                .ThenBy(item => item.Name)
                .ToList();
        }

        public List<Item> FilterbyType(ItemType type)
        {
            return items.Where(item => item.Type == type).ToList();
        }

        public List<Item> FindByValueRange(int min, int max)
        {
            return items.Where(item => item.Value >= min && item.Value <= max).ToList();
        }

        public bool ContainsItem(string name)
        {
            return items.Any(item =>
                item.Name.Contains(name, StringComparison.OrdinalIgnoreCase));
        }
    }
}