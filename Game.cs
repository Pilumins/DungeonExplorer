using DungeonExplorer;
using System;
using System.Threading;


namespace DungeonExplorer
{

    internal class Game
    {
        // Fields to store the player and the current room
        private Player player;
        private Room currentRoom;
        private Monster currentMonster;
        private GameMap gameMap;
        public Game()
        {
            gameMap = new GameMap();
            player = new Player("User", 100); // this will create a player with 100 health

            Room room0 = new Room("Starting Room");
            Room room1 = new Room("You are in a messy dungeon.There is a Vampire in this room!..");
            Room room2 = new Room("You are in a unlit dungeon.There is a healing potion on the ground near by.");
            Room room3 = new Room("You are in a dark dungeon.There is a wooden sword on the ground near by.");
            Room room4 = new Room("You are in a dark dungeon. vampire");

            gameMap.AddRoom("Starting Room", room0);
            gameMap.AddRoom("Room 1", room1);
            gameMap.AddRoom("Room 2", room2);
            gameMap.AddRoom("Room 3", room3);
            gameMap.AddRoom("Room 4", room4);

            room0.AddConnectedRoom("north", room1);
            room1.AddConnectedRoom("north", room2);
            room2.AddConnectedRoom("south", room1);
            room2.AddConnectedRoom("east", room3);
            room3.AddConnectedRoom("west", room2);
            room3.AddConnectedRoom("south", room4);

            //sets starting room.
            room1.SetMonster(new Monster("Vampire", 30));
            room2.SetItem("healing potion");
            room3.SetItem("wooden sword");
            room4.SetMonster(new Monster("zombie", 40));

            currentRoom = gameMap.GetRoom("Starting Room");
           // gets the monster in the room.
        }
        public void Start()
        {
            Console.WriteLine("\n\n\nDungeon Explorer"); //displays the title of the game.
            bool playing = true; // this will check to see if the game is still running
            while (playing)
            {
              // Shows the current room info
              Console.WriteLine(currentRoom.GetDescription());
              Console.WriteLine("Items in room: " + currentRoom.ListContents());
                // Shows available exits
              Console.WriteLine("Exits: " + currentRoom.ListConnectedRooms());

                // make the player choose an option
              Console.WriteLine("Pick one of these options below \n(You have to type out the words that you want to do so for example:\n to use a healing potion you would have to type out 'use healing potion' ");
              Console.WriteLine("Options: \n1.'pick up [item]', \n2.'inventory', \n3.'move [direction]',\n4. 'attack'\n5.'use healing potion'\n'exit' \n");

                // player input
                // code has been changed based on AZUoL's feedback(added .Trim)
                string input = Console.ReadLine().ToLower().Trim();

                // this will process the player input
                if (input.StartsWith("pick up"))
                {
                    string item = input.Substring(8).Trim();
                    // checks if the item is in the room and its case insensitive.
                    if (currentRoom.ListContents().ToLower().Contains(item))
                    {
                        currentRoom.RemoveItem(item);
                        if (item.Equals("dagger", StringComparison.OrdinalIgnoreCase))
                        {
                            Weapon Dagger = new Weapon("Dagger", 15);
                            player.PickUpItem(Dagger);
                        }
                        else if (item.Equals("healing potion", StringComparison.OrdinalIgnoreCase))
                        {
                            Potion healingPotion = new Potion("Healing Potion", 50);
                            player.PickUpItem(healingPotion);
                        }
                        else if (item.Equals("wooden sword", StringComparison.OrdinalIgnoreCase))
                        {
                            Weapon woodenSword = new Weapon("Wooden Sword", 10);
                            player.PickUpItem(woodenSword);
                        }
                        else
                        {
                            Console.WriteLine($"no mapping was found for {item}");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"No {item} in this room.");
                    }
                }
                else if (input == "attack")
                {
                    if (currentMonster != null && currentMonster.Health > 0)
                    {
                        Console.WriteLine("Attacking Monster...");
                        player.Attack(currentMonster);
                        if (currentMonster.Health > 0)
                        {
                            currentMonster.Attack(player);
                        }
                        else
                        {
                            Console.WriteLine($"{currentMonster.Name} was defeated");
                            currentMonster = null; // will remove the monster after defeat.
                        }
                    }
                    else
                    {
                        Console.WriteLine("No monster to attack.");
                    }
                }
                else if (input == "inventory")
                {
                    // display the player inv
                    Console.WriteLine("Your inventory: " + player.InventoryContents());
                }
                else if (input.StartsWith("move"))
                {
                    string direction = input.Substring(5).Trim();
                    Room nextRoom = currentRoom.GetConnectedRoom(direction);
                    if (nextRoom != null)
                    {
                        currentRoom = nextRoom;
                        currentMonster = currentRoom.GetMonster();
                        Console.WriteLine($"You moved to the {direction}");
                    }
                    else
                    {
                        Console.WriteLine("You cannot go that way.");
                    }
                }
                else if (input == "exit")
                {
                    // exit game
                    Console.WriteLine("Thanks for playing!");
                    playing = false;
                }

                else if (input == "use healing potion")

                // if players input is "use healing potion" it will check for the potion in the inventory and only then use it which will restore them health,
                {
                    Item healingPotion = player.GetItemFromInventory("healing potion");
                    if (healingPotion != null && healingPotion is Potion potion)
                    {
                        potion.Use(player); 
                        player.RemoveItemFromInventory(healingPotion); 
                        Console.WriteLine("You restored 50 health! good job!");
                    }
                    else
                    {
                        Console.WriteLine("you dont have a healing potion.");
                    }
                }

                else
                {
                    //handle invalid inputs
                    Console.WriteLine("Invalid input. Please try again.");
                }
            }
        }
    }
}