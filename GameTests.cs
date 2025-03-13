using System;
using System.Diagnostics;

namespace DungeonExplorer
{
    internal class GameTests
    {
        public void RunTests()
        {
            // Runs all the test methods so that we can verify the code.
            TestPlayerInventory();
            TestRoomConnections();
            TestErrorHandling();
            Console.WriteLine("All tests passed.");
        }

        private void TestPlayerInventory()
        {
            // Test if the player inventory management is working as intended.
            Player player = new Player("Player", 100);
            player.PickUpItem("diamonds");
            player.PickUpItem("gold coins");
            player.PickUpItem("wooden sword");
            Debug.Assert(player.InventoryContents() == "diamonds, gold coins, wooden sword", "Inventory contents should match the items picked up.");
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
