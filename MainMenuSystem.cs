namespace myMainMenuSystem;
    public class InventoryManager
    {
        private Inventory inventory;
        private SpecializedInventory specializedInventory;
        private static int nextId = 1; // 🆔 For generating unique item IDs
        
    public InventoryManager()
    {
        inventory = new Inventory(50); // 50 SLOTS capacity (not kg - check Inventory class!)
        specializedInventory = new SpecializedInventory();
    }
    
    public void Run()
    {
        Console.WriteLine("=== RPG INVENTORY SYSTEM ===");
        Console.WriteLine("Created by [Your Name]");
        
        bool exit = false;
        
        while (!exit)
        {
            DisplayMainMenu();
            string choice = Console.ReadLine();
            
            switch (choice)
            {
                case "1": AddNewItem(); break;
                case "2": RemoveItem(); break;
                case "3": ViewAllItems(); break;
                case "4": SortItems(); break;
                case "5": FilterItems(); break;
                case "6": UseSpecializedInventory(); break;
                case "7": GenerateSampleData(); break;
                case "8": DisplayStatistics(); break;
                case "0": exit = true; break;
                default: Console.WriteLine("Invalid choice!"); break;
            }
            
            if (!exit)
            {
                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
            }
        }
        
        Console.WriteLine("Goodbye!");
    }
    
    private void DisplayMainMenu()
    {
        Console.Clear();
        Console.WriteLine("=== MAIN MENU ===");
        Console.WriteLine($"Items: {inventory.ItemCount} | Weight: {inventory.CurrentWeight}/{inventory.Capacity}kg");
        Console.WriteLine("1. Add Item");
        Console.WriteLine("2. Remove Item");
        Console.WriteLine("3. View All Items");
        Console.WriteLine("4. Sort Items");
        Console.WriteLine("5. Filter Items");
        Console.WriteLine("6. Specialized Inventory (Potions/Quest)");
        Console.WriteLine("7. Generate Sample Data");
        Console.WriteLine("8. Statistics");
        Console.WriteLine("0. Exit");
        Console.Write("Choice: ");
    }
    
    // ➕ METHOD 1: ADD NEW ITEM - Creates and adds an item to inventory
    private void AddNewItem()
    {
        Console.WriteLine("\n--- Add New Item ---");
        
        // 📝 Get item name
        Console.Write("Item Name: ");
        string name = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(name))
        {
            Console.WriteLine("❌ Item name cannot be empty!");
            return;
        }
        
        // 📝 Get item type (convert number to enum)
        ItemType type = ItemType.Weapon; // Default
        Console.WriteLine("Item Type (1-Weapon, 2-Armor, 3-Potion, 4-Material, 5-Quest): ");
        string typeInput = Console.ReadLine();
        
        if (int.TryParse(typeInput, out int typeNum) && typeNum >= 1 && typeNum <= 5)
        {
            type = (ItemType)(typeNum - 1); // Convert 1→Weapon, 2→Armor, etc.
        }
        else
        {
            Console.WriteLine("❌ Invalid type! Using default (Weapon).");
        }
        
        // 📝 Get item value (gold)
        Console.Write("Item Value (gold): ");
        string valueInput = Console.ReadLine();
        if (!int.TryParse(valueInput, out int value))
        {
            Console.WriteLine("❌ Invalid value! Using default (10).");
            value = 10;
        }
        
        // 📝 Get item weight
        Console.Write("Item Weight (kg): ");
        string weightInput = Console.ReadLine();
        if (!float.TryParse(weightInput, out float weight))
        {
            Console.WriteLine("❌ Invalid weight! Using default (1.0).");
            weight = 1.0f;
        }
        
        // 📝 Get description
        Console.Write("Description (optional): ");
        string description = Console.ReadLine();
        
        // 🆔 Generate unique ID
        int id = nextId++;
        
        // 🏗️ Create the new item
        Item newItem = new Item(id, name, type, value, weight);
        if (!string.IsNullOrEmpty(description))
        {
            newItem.Description = description;
        }
        
        // 📦 Try to add to inventory
        if (inventory.AddItem(newItem))
        {
            Console.WriteLine($"✅ Successfully added: {newItem}");
        }
        else
        {
            Console.WriteLine($"❌ Failed to add {name}! Inventory may be full or too heavy.");
            nextId--; // Rollback ID since we didn't use it
        }
    }
    
    // ➖ METHOD 2: REMOVE ITEM - Remove by ID or selection
    private void RemoveItem()
    {
        Console.WriteLine("\n--- Remove Item ---");
        
        if (inventory.ItemCount == 0)
        {
            Console.WriteLine("📭 Inventory is empty! Nothing to remove.");
            return;
        }
        
        // Show current items for reference
        ViewAllItems();
        
        Console.WriteLine("\nRemove by:");
        Console.WriteLine("1. Enter Item ID");
        Console.WriteLine("2. Select by number");
        Console.Write("Choice: ");
        
        string choice = Console.ReadLine();
        
        if (choice == "1")
        {
            // Remove by ID
            Console.Write("Enter Item ID to remove: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                if (inventory.RemoveItem(id))
                {
                    Console.WriteLine($"✅ Item with ID {id} removed!");
                }
                else
                {
                    Console.WriteLine($"❌ Item with ID {id} not found!");
                }
            }
            else
            {
                Console.WriteLine("❌ Invalid ID!");
            }
        }
        else if (choice == "2")
        {
            // Remove by position
            Console.Write("Enter item number to remove (1-{0}): ", inventory.ItemCount);
            if (int.TryParse(Console.ReadLine(), out int pos) && pos >= 1 && pos <= inventory.ItemCount)
            {
                // Need a way to get item by index - we'll need to add this method to Inventory
                // For now, let's list items and ask for ID instead
                Console.WriteLine("⚠️ Please use ID to remove for now.");
                RemoveItem(); // Recursive call to try again
            }
            else
            {
                Console.WriteLine("❌ Invalid number!");
            }
        }
        else
        {
            Console.WriteLine("❌ Invalid choice!");
        }
    }
    
    // 👁️ METHOD 3: VIEW ALL ITEMS - Display the entire inventory
    private void ViewAllItems()
    {
        Console.WriteLine("\n--- All Items ---");
        
        if (inventory.ItemCount == 0)
        {
            Console.WriteLine("📭 Inventory is empty!");
            return;
        }
        
        // We need a way to access items - let's add a method to Inventory
        // For now, we'll list them manually (we'll need to add a GetItems method to Inventory)
        Console.WriteLine($"📊 Total Items: {inventory.ItemCount} | Total Weight: {inventory.CurrentWeight}/{inventory.Capacity}kg");
        Console.WriteLine("──────────────────────────────────");
        
        // This requires Inventory to expose items - we'll add a method
        Console.WriteLine("⚠️ Need to implement item listing!");
        
        // Temporary workaround - we'll use a method that doesn't exist yet
        // inventory.ListAllItems(); // We need to add this to Inventory class
    }
    
    // 🔠 METHOD 4: SORT ITEMS - Sort by different criteria
    private void SortItems()
    {
        Console.WriteLine("\n--- Sort Items ---");
        
        if (inventory.ItemCount < 2)
        {
            Console.WriteLine("📭 Not enough items to sort!");
            return;
        }
        
        Console.WriteLine("Sort by:");
        Console.WriteLine("1. Name (A-Z)");
        Console.WriteLine("2. Name (Z-A)");
        Console.WriteLine("3. Value (Low to High)");
        Console.WriteLine("4. Value (High to Low)");
        Console.WriteLine("5. Weight (Light to Heavy)");
        Console.WriteLine("6. Weight (Heavy to Light)");
        Console.WriteLine("7. Type");
        Console.Write("Choice: ");
        
        string choice = Console.ReadLine();
        
        // We need to add sorting methods to Inventory
        // For now, we'll just show what would happen
        Console.WriteLine($"🔄 Sorting items by option {choice}...");
        
        // This would call something like:
        // inventory.SortBy(choice);
        
        ViewAllItems(); // Show sorted results
    }
    
    // 🔍 METHOD 5: FILTER ITEMS - Show only certain types
    private void FilterItems()
    {
        Console.WriteLine("\n--- Filter Items ---");
        
        if (inventory.ItemCount == 0)
        {
            Console.WriteLine("📭 Inventory is empty!");
            return;
        }
        
        Console.WriteLine("Show only:");
        Console.WriteLine("1. Weapons");
        Console.WriteLine("2. Armor");
        Console.WriteLine("3. Potions");
        Console.WriteLine("4. Materials");
        Console.WriteLine("5. Quest Items");
        Console.WriteLine("6. [Clear Filter]");
        Console.Write("Choice: ");
        
        string choice = Console.ReadLine();
        
        if (choice == "6")
        {
            Console.WriteLine("🔄 Filter cleared - showing all items");
            ViewAllItems();
            return;
        }
        
        if (int.TryParse(choice, out int typeNum) && typeNum >= 1 && typeNum <= 5)
        {
            ItemType filterType = (ItemType)(typeNum - 1);
            
            // We need a filter method in Inventory
            // List<Item> filtered = inventory.GetItemsByType(filterType);
            
            Console.WriteLine($"🔍 Showing only {filterType}s:");
            Console.WriteLine("──────────────────────────────────");
            
            // Would display filtered items
            // foreach (var item in filtered) { Console.WriteLine(item); }
            
            Console.WriteLine("⚠️ Need to implement filtering!");
        }
        else
        {
            Console.WriteLine("❌ Invalid choice!");
        }
    }
    
    // 📦 METHOD 6: USE SPECIALIZED INVENTORY - Switch to potions/quest view
    private void UseSpecializedInventory()
    {
        Console.WriteLine("\n--- Specialized Inventory (Potions & Quest Items) ---");
        
        // This would show only potions and quest items
        // Could be in a separate view or use filtering
        
        Console.WriteLine("📦 Specialized Inventory Features:");
        Console.WriteLine("1. View Potions");
        Console.WriteLine("2. View Quest Items");
        Console.WriteLine("3. Use Potion");
        Console.WriteLine("4. Track Quest Items");
        Console.Write("Choice: ");
        
        string choice = Console.ReadLine();
        
        // Would call methods on specializedInventory
        switch (choice)
        {
            case "1": 
                Console.WriteLine("🧪 Potions:");
                // specializedInventory.ListPotions();
                break;
            case "2":
                Console.WriteLine("❓ Quest Items:");
                // specializedInventory.ListQuestItems();
                break;
            case "3":
                Console.Write("Enter potion ID to use: ");
                // specializedInventory.UsePotion(id);
                break;
            case "4":
                Console.WriteLine("📍 Quest Progress:");
                // specializedInventory.ShowQuestProgress();
                break;
            default:
                Console.WriteLine("❌ Invalid choice!");
                break;
        }
        
        Console.WriteLine("⚠️ SpecializedInventory needs implementation!");
    }
    
    // 🧪 METHOD 7: GENERATE SAMPLE DATA - Create test items
    private void GenerateSampleData()
    {
        Console.WriteLine("\n--- Generating Sample Data ---");
        
        // Create some sample items for testing
        Item[] sampleItems = new Item[]
        {
            new Item(nextId++, "Iron Sword", ItemType.Weapon, 100, 5.0f) 
                { Description = "A basic iron sword" },
            new Item(nextId++, "Leather Armor", ItemType.Armor, 75, 3.5f) 
                { Description = "Provides basic protection" },
            new Item(nextId++, "Health Potion", ItemType.Potion, 50, 0.5f) 
                { Description = "Restores 50 HP" },
            new Item(nextId++, "Iron Ore", ItemType.Material, 20, 2.0f) 
                { Description = "Can be smelted into iron" },
            new Item(nextId++, "Ancient Artifact", ItemType.Quest, 0, 1.0f) 
                { Description = "Return to the museum" },
            new Item(nextId++, "Steel Sword", ItemType.Weapon, 250, 4.5f) 
                { Description = "A finely crafted sword" },
            new Item(nextId++, "Mana Potion", ItemType.Potion, 60, 0.5f) 
                { Description = "Restores 30 MP" }
        };
        
        int added = 0;
        foreach (Item item in sampleItems)
        {
            if (inventory.AddItem(item))
            {
                added++;
                Console.WriteLine($"✅ Added: {item.Name}");
            }
            else
            {
                Console.WriteLine($"❌ Failed to add: {item.Name} (inventory full)");
                break;
            }
        }
        
        Console.WriteLine($"\n📊 Added {added} sample items to inventory!");
    }
    
    // 📊 METHOD 8: DISPLAY STATISTICS - Show inventory analytics
    private void DisplayStatistics()
    {
        Console.WriteLine("\n--- Inventory Statistics ---");
        
        if (inventory.ItemCount == 0)
        {
            Console.WriteLine("📭 No items to analyze!");
            return;
        }
        
        // Calculate statistics
        int totalItems = inventory.ItemCount;
        float totalWeight = inventory.CurrentWeight;
        float avgWeight = totalWeight / totalItems;
        
        // We need to calculate these from inventory items
        int totalValue = 0;
        int mostValuable = 0;
        string mostValuableName = "";
        int weaponCount = 0, armorCount = 0, potionCount = 0, materialCount = 0, questCount = 0;
        
        // Would loop through items to calculate
        // foreach (Item item in inventory.GetItems())
        // {
        //     totalValue += item.Value;
        //     if (item.Value > mostValuable)
        //     {
        //         mostValuable = item.Value;
        //         mostValuableName = item.Name;
        //     }
        //     
        //     switch (item.Type)
        //     {
        //         case ItemType.Weapon: weaponCount++; break;
        //         case ItemType.Armor: armorCount++; break;
        //         case ItemType.Potion: potionCount++; break;
        //         case ItemType.Material: materialCount++; break;
        //         case ItemType.Quest: questCount++; break;
        //     }
        // }
        
        // Display stats
        Console.WriteLine($"📦 Total Items: {totalItems}");
        Console.WriteLine($"⚖️ Total Weight: {totalWeight}kg");
        Console.WriteLine($"📏 Average Weight: {avgWeight:F2}kg");
        Console.WriteLine($"💰 Total Value: {totalValue} gold");
        Console.WriteLine($"💎 Most Valuable: {mostValuableName} ({mostValuable} gold)");
        
        Console.WriteLine("\n📊 Items by Type:");
        Console.WriteLine($"  ⚔️ Weapons: {weaponCount}");
        Console.WriteLine($"  🛡️ Armor: {armorCount}");
        Console.WriteLine($"  🧪 Potions: {potionCount}");
        Console.WriteLine($"  ⚒️ Materials: {materialCount}");
        Console.WriteLine($"  ❓ Quest: {questCount}");
        
        Console.WriteLine("\n⚠️ Statistics need actual implementation!");
    }
}



// 🔧 ADDITIONS NEEDED TO INVENTORY CLASS:
/*
public class Inventory
{
    // Need to add:
    public List<Item> GetItems() { return _items; }  // To access items
    public void ListAllItems() { ... }                // To display items
    public bool RemoveItem(int id) { ... }            // Remove by ID
    public List<Item> GetItemsByType(ItemType type) { ... } // Filter by type
    public void SortBy(string criteria) { ... }       // Sort items
}
*/

// 🎮 USAGE EXAMPLE:
/*
InventoryManager manager = new InventoryManager();
manager.Run();

// This will:
// 1. Show main menu
// 2. Player chooses options
// 3. Program responds accordingly
// 4. Loops until player chooses 0
*/

// 🧠 ADHD-FRIENDLY SUMMARY:

// • InventoryManager = The "GAME MASTER" running the show
// • Run() = The main "GAME LOOP" that keeps going
// • Switch = The "MENU SYSTEM" routing choices
// • AddNewItem() = "CREATE ITEM" wizard
// • RemoveItem() = "DELETE ITEM" with confirmation
// • ViewAllItems() = "SHOW INVENTORY" display
// • GenerateSampleData() = "CHEAT CODE" for testing
// • nextId = "AUTO-INCREMENT" ID counter (like item numbers in a shop)