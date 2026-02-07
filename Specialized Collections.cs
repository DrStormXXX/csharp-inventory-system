using System;
using System.ComponentModel;
using System.Net.ServerSentEvents;

namespace mySpecializedCollections
{
    public class SpecializedInventory
    {
        private Stack<Item> potionStack; //Last-IN-First-Out for potions
        private Queue<Item> questQueue; //First-In-First-Outfor quest items

        public SpecializedInventory()
        {
            potionStack = new Stack<Item>();
            questQueue = new Queue<Item>();
        }

        //Potion Methods
        public void PushPotion(Item potion)
        {
            if (potion.Type == ItemType.Potion)
            {
                potionStack.Push(potion);
                Console.WriteLine($"Pushed {potion.Name} onto potion stack.");
            }
        }

        public Item PopPotion()
        {
            if(potionStack.Count > 0)
            {
                var potion = potionStack.Pop();
                Console.WriteLine($"Popped {potion.Name} from potion stack.");
                return potion;
            }

            Console.WriteLine("Potion stack is empty!");
            return null;
        }

        //Quest item methode
        public void EnqueueQuestItem(Item questItem)
        {
            if (questItem.Type == ItemType.Quest)
            {
                questQueue.Enqueue(questItem);
                Console.WriteLine($"Queued {questItem.Name} to quest queue.");
            }
        }

        public Item DequeueQuest
    }
}