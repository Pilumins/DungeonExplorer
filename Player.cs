using System.Collections.Generic;
using System;
using DungeonExplorer;

namespace DungeonExplorer
{
    public class Player : Creature
    {
        private List<Item> inventory;

        public Player(string name, int health) : base(name, health)
        {
            inventory = new List<Item>();
        }
        public void PickUpItem(Item item)
        {
            inventory.Add(item);
            Console.WriteLine($"{item.Name} added to your inventory.");
        }
        public Item GetItemFromInventory(string itemName)
        {
            return inventory.Find(item => item.Name.Equals(itemName,StringComparison.OrdinalIgnoreCase));
        }
        public void RemoveItemFromInventory(Item item)
        {
            inventory.Remove(item);
            Console.WriteLine($" {item.Name} was removed from the inventory");
        }

        // method to list the contents of a players inventory
        public string InventoryContents()
        {
            return inventory.Count > 0
                ? string.Join(", ", inventory.ConvertAll(item => item.Name))
                : "Your inventory is empty.";
        }

        public override void Attack(Creature target)
        {
            Console.WriteLine($"{Name} attacks {target.Name}");
            target.TakeDamage(8); // this will decrease the players health
        }
    }
}