using System;
using System.Diagnostics;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;

namespace myMainMenuSystem
{
    public class InventoryManager
    {
        private Inventory inventory;
        private SpecializedInventory specializedInventory;

        public InventoryManager()
        {
            inventory = new Inventory(50); // 50kg capacity
            specializedInventory = new SpecializedInventory();
        }

        public void Run()
        {
            Console.WriteLine("=== RPG INVENTORY SYSTEM ===");
            Console.WriteLine("Created by Njabulo Matshika");

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
            Console.WriteLine($"Items: {inventory.ItemCount} | Weight: {inventory.CurrentWeight}/{inventory.maxWeight}kg");
            Console.WriteLine("1. Add Item");
            Console.WriteLine("2. Remove Item");
            Console.WriteLine("3. View All Items");
            Console.WriteLine("4. Sort Items");
            Console.WriteLine("5. Filter Items");
            Console.WriteLine("6. Specialized Inventory (Potions/Quest)");
            Console.WriteLine("7. Generate Sample Data");
            Console.WriteLine("8. Statistics");
            Console.WriteLine("0. Exit");
            Console.WriteLine("Choice: ");
        }

        private void AddNewItem()
        {
            //Implement interactive item creation
            Console.WriteLine("\n--- Add New Item ---");

            Console.WriteLine("Item Name: ");
            string name = Console.ReadLine();

            Console.WriteLine("Item Type (1-Weapon, 2-Armor, 3-Potion, 4-Material, 5-Quest: ): ");
            string typeInput = Console.ReadLine();

            Console.WriteLine("Item Value(R): ");
            int value = Console.ReadLine();

            Console.WriteLine("Item Weight(kg): ");
            float weight = Console.ReadLine();

            Console.WriteLine("Item Description: ");
            string description = Console.ReadLine();
        }
        private void RemoveItem()
        {
            //Implement interactive item creation
            Console.WriteLine("\n--- Add New Item ---");

            Console.WriteLine("Item Name: ");
            string name = Console.ReadLine();

            Console.WriteLine("Item Type (1-Weapon, 2-Armor, 3-Potion, 4-Material, 5-Quest: ): ");
            string typeInput = Console.ReadLine();

            Console.WriteLine("Item Value(R): ");
            int value = Console.ReadLine();

            Console.WriteLine("Item Weight(kg): ");
            float weight = Console.ReadLine();

            Console.WriteLine("Item Description: ");
            string description = Console.ReadLine();
        }
        private void ViewAllItems()
        {
            //Implement interactive item creation
            Console.WriteLine("\n--- Add New Item ---");

            Console.WriteLine("Item Name: ");
            string name = Console.ReadLine();

            Console.WriteLine("Item Type (1-Weapon, 2-Armor, 3-Potion, 4-Material, 5-Quest: ): ");
            string typeInput = Console.ReadLine();

            Console.WriteLine("Item Value(R): ");
            int value = Console.ReadLine();

            Console.WriteLine("Item Weight(kg): ");
            float weight = Console.ReadLine();

            Console.WriteLine("Item Description: ");
            string description = Console.ReadLine();
        }
        private void AddNewItem()
        {
            //Implement interactive item creation
            Console.WriteLine("\n--- Add New Item ---");

            Console.WriteLine("Item Name: ");
            string name = Console.ReadLine();

            Console.WriteLine("Item Type (1-Weapon, 2-Armor, 3-Potion, 4-Material, 5-Quest: ): ");
            string typeInput = Console.ReadLine();

            Console.WriteLine("Item Value(R): ");
            int value = Console.ReadLine();

            Console.WriteLine("Item Weight(kg): ");
            float weight = Console.ReadLine();

            Console.WriteLine("Item Description: ");
            string description = Console.ReadLine();

        private void AddNewItem()
        {
            //Implement interactive item creation
            Console.WriteLine("\n--- Add New Item ---");

            Console.WriteLine("Item Name: ");
            string name = Console.ReadLine();

            Console.WriteLine("Item Type (1-Weapon, 2-Armor, 3-Potion, 4-Material, 5-Quest: ): ");
            string typeInput = Console.ReadLine();

            Console.WriteLine("Item Value(R): ");
            int value = Console.ReadLine();

            Console.WriteLine("Item Weight(kg): ");
            float weight = Console.ReadLine();

            Console.WriteLine("Item Description: ");
            string description = Console.ReadLine();

        private void AddNewItem()
        {
            //Implement interactive item creation
            Console.WriteLine("\n--- Add New Item ---");

            Console.WriteLine("Item Name: ");
            string name = Console.ReadLine();

            Console.WriteLine("Item Type (1-Weapon, 2-Armor, 3-Potion, 4-Material, 5-Quest: ): ");
            string typeInput = Console.ReadLine();

            Console.WriteLine("Item Value(R): ");
            int value = Console.ReadLine();

            Console.WriteLine("Item Weight(kg): ");
            float weight = Console.ReadLine();

            Console.WriteLine("Item Description: ");
            string description = Console.ReadLine();
        }                      
    }
}