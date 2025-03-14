﻿using System.Collections.Generic;
using System;

namespace DungeonExplorer
{
    public class Player
    {
        // properties for players name and health
        public string Name { get; private set; } // player name
        public int Health { get; private set; } // player health
        private List<string> inventory = new List<string>(); // player inventory
     
        public Player(string name, int health) 
        {
            // initializes the players name with their inventory and health.
            Name = name;
            Health = health;
            inventory = new List<string>();
        }
        // method to add an item to the players inventory
        public void PickUpItem(string item)
        {
            inventory.Add(item);
            Console.WriteLine($"{item} added to your inventory.");
        }

        // method to list the contents of a players inventory
        public string InventoryContents()
        {
            return inventory.Count > 0 ? string.Join(", ", inventory) : "Your inventory is empty.";
        }

        // decrease the players health
        public void TakeDamage(int damage)
        {
            Health -= damage;
            if (Health < 0) Health = 0;
            Console.WriteLine($"you took {damage} damage. your current health is {Health}");
        }
        // method to heal player
        public void Heal(int amount)
        {
            Health += amount;
            Console.WriteLine($"you have healed {amount} health. your current health is {Health}");
        }
    }
}