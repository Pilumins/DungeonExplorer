using System;
using System.Collections.Generic;
using DungeonExplorer;

namespace DungeonExplorer
{
    public class Room
    {
        private List<string> items = new List<string>();
        private string description;
        private string item;
        private Monster monster;
        private Dictionary<string, Room> connectedRooms; // connected rooms

        public Room(string description)
        {
            this.description = description;
            this.item = null; // removes items by default.
            this.monster = null; // removes the  monsters by default.    
            this.connectedRooms = new Dictionary<string, Room>();
        }

        public string GetDescription()
        {
            string itemList = items.Count > 0 ? $" Items: {string.Join(", ",items)}." : "";
            // so this will check if monster is in room and if it is noit null it will then display health and name
            string monsterDescription = monster != null ? $" There is a {monster.Name} here with {monster.Health} health!" : "";
            return description + itemList + monsterDescription;
        }

        public void AddItem(string item)
        {
            items.Add(item);
            Console.WriteLine($"{item} added to the room.");
        }
        public void SetItem(string item)
        {
            if (!items.Contains(item))
            {
                items.Add(item); // Adds te item to the list
                Console.WriteLine($" {item} has been added to the room,");
            }
            else
            {
                Console.WriteLine($" {item} is already in the room.");
            }
        }
        public void SetMonster(Monster newMonster)
        {
            monster = newMonster; // Assigns te Monster object to the room
        }

        public void RemoveMonster()
        {
            monster = null;
        }
        public Monster GetMonster()
        {
            return monster; // Return the monster within the room
        }

        public void RemoveItem()
        {
            item = null;
        }
        public string ListContents()
        {
            if (items.Count > 0)
            {
                return $"Items: {string.Join(", ", items)}";
            }
            if (monster != null)
            {
                return $"Monster: {monster.Name}";
            }
            return "This room has nothing.";
        }


        public void RemoveItem(string item)
        {
            if (items.Remove(item))
            {
                Console.WriteLine($"{item} was been removed from the room.");
            }
            else
            {
                Console.WriteLine($"{item} is currently not in this room.");
            }
        }


        // adds a connected room in a specificed direction
        public void AddConnectedRoom(string direction, Room room)
        {
            connectedRooms[direction] = room;
        }
        // get a connected room in the specified direction
        public Room GetConnectedRoom(string direction)
        {
            return connectedRooms.ContainsKey(direction) ? connectedRooms[direction] : null;
        }
        public string ListConnectedRooms()
        {
            return connectedRooms.Count > 0
                ? string.Join(", ", connectedRooms.Keys)
                : "There are no exits.";
        }
    }
}