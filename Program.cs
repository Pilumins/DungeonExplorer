using System;

namespace DungeonExplorer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Creates an instance of GameTests so that we can run the tests.
                GameTests tests = new GameTests();
                tests.RunTests();
                // creates an instances of the game class so that we can start the game.
                Game game = new Game();
                game.Start();
            }
            catch (Exception ex)
            {
                //Handles exceptions that occur while playing the game and while testing.
                Console.WriteLine("An error occurred: " + ex.Message);
            }
            finally
            {
                //Displays thank you message for the user and will prompt them to exit the game.
                Console.WriteLine("Thanks for playing Dungeon Explorer!");
                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
            }
        }
    }
}
