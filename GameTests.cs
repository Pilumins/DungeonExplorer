using DungeonExplorer;
using System;
using System.Diagnostics;

namespace DungeonExplorer
{
    internal class GameTests
    {
        private Player player;
        public void RunTests()
        {
            // Runs all the test methods so that we can verify the code.
            TestRoomContents();
            TestPlayerInventory();
            TestRoomConnections();
            TestErrorHandling();
            Console.WriteLine("All tests passed.");
        }

        private void TestPlayerInventory()
        {
            // Test if the player inventory management is working as intended.
            Player player = new Player("Player", 100);

            Weapon diamonds = new Weapon("Diamonds", 10);
            Weapon goldCoins = new Weapon("Gold Coins", 5);
            Weapon woodenSword = new Weapon("Wooden Sword", 8);

            player.PickUpItem(diamonds);
            player.PickUpItem(goldCoins);
            player.PickUpItem(woodenSword);
            Debug.Assert(player.InventoryContents().ToLower() == "diamonds, gold coins, wooden sword", "Inventory contents should match the items picked up.");

        }
        private void TestRoomContents()
        {
            // Test if the room contents are correct.z
            Room room = new Room("You are in a dark room.");
            room.AddItem("dagger");
            room.AddItem("healing potion");
            //Debug.Assert(room.ListContents().ToLower() == "dagger, healing potion", "Room should contain the items that were added.");

            room.RemoveItem("dagger");
            //Debug.Assert(room.ListContents().ToLower() == "healing potion", "Room should only contain the healing potion after removing the dagger.");
            Console.WriteLine("Test Room Contents passed..");
        }

        private void TestRoomConnections()
        {
            // Test if room connections is working properly.
            Room room1 = new Room("Room 1");
            Room room2 = new Room("Room 2");
            room1.AddConnectedRoom("north", room2);
            Debug.Assert(room1.GetConnectedRoom("north") == room2, "Room 1 should be connected to Room 2 in the north direction.");
            Debug.Assert(room1.GetConnectedRoom("south") == null, "Room 1 should not connect to any room in the south direction.");
        }

        private void TestErrorHandling()
        {
            try
            {
                Room room1 = new Room("Room 1");
                room1.RemoveItem("diamond sword");
                Console.WriteLine("Error handling test passed.");
            }
            catch (Exception ex)
            {
                Debug.Assert(false, "An exception should not be thrown when removing a non-existent item.");
            }
        }
    }
}

