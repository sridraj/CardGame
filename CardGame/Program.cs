using System;
using CardGame.Common;
namespace CardGame
{
    class Program
    {
        private readonly string gameOverview;
        Program()
        {
            gameOverview = string.Concat(Constants.greet, "\n \n", Constants.userInstruction, "\n \n 1.",
                Constants.playCard, "\n 2.", Constants.shuffleDeck, "\n \n 3.", Constants.restartGame);
        }

        static void Main(string[] args)
        {
            var program = new Program();
            CardGame game = new CardGame();

            // Instruction to the user
            Console.WriteLine(program.gameOverview);

            // Continue the game till there is card left in the deck
            game.StartGame();

            // Check if user wants to start new game once deck is empty
            Console.WriteLine("\n" + Constants.newGame);

            if(Console.ReadLine().ToLowerInvariant() == "yes")
            {
                Console.WriteLine(program.gameOverview);

                game.StartGame();
            }
        }
    }
}
