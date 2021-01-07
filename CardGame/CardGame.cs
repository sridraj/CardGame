using CardGame.Common;
using CardGame.Interfaces;
using CardGame.Models;
using System;

namespace CardGame
{
    public class CardGame : ICardGame
    {
        private static Card[] deck;
        private static Random random = new Random();

        /// <summary>
        /// Continue the game till the deck is empty
        /// </summary>
        public void StartGame()
        {
            InitializeDeckOfCards();

            while (deck.Length != 0)
            {
                // Read user input
                string userInput = Console.ReadLine().ToLowerInvariant();

                if (userInput == Constants.shuffleDeck)
                {
                    ShuffleDeck();
                    Console.WriteLine("\n" + Constants.shuffleSuccess);
                }

                else if (userInput == Constants.restartGame)
                {
                    InitializeDeckOfCards();
                    Console.WriteLine(Constants.restartMsg);
                }

                else if (userInput == Constants.playCard)
                {
                    PlayCard();
                }

                else if(userInput == Constants.printDeck)
                {
                    PrintDeck();
                }

                else
                {
                    Console.WriteLine(Constants.invalidInput);
                }
            }
        }


        /// <summary>
        /// Creates deck of 52 cards on game start and shuffles them
        /// </summary>
        public void InitializeDeckOfCards()
        {
            try
            {
                int index = 0;
                deck = new Card[52];
                foreach (string suit in Card.SuitsArray)
                {
                    for (int i = 1; i <= 13; i++)
                    {
                        string value;
                        switch (i)
                        {
                            case 1:
                                value = "Ace";
                                break;
                            case 11:
                                value = "Jack";
                                break;
                            case 12:
                                value = "Queen";
                                break;
                            case 13:
                                value = "King";
                                break;
                            default:
                                value = i.ToString();
                                break;

                        }

                        Card card = new Card(value, suit);
                        deck[index] = card;
                        index++;
                    }
                }

                // Shuffle the Deck on starting the game
                ShuffleDeck();
            }
            catch
            {
                Console.WriteLine("\n Error occured while creating the deck! please try restarting the game..");
            }
        }

        /// <summary>
        /// Prints the items present in the deck
        /// </summary>
        public void PrintDeck()
        {
            try
            {
                for (int i = 0; i < deck.Length; i++)
                {
                    Console.WriteLine($"{deck[i].value} {deck[i].suit}");
                }

                Console.WriteLine("\n Number of Cards left = " + deck.Length);
            }
            catch
            {
                Console.WriteLine("Error occured while prining the deck!");
            }
        }

        /// <summary>
        /// Shuffles using Fisher-Yates Shuffle algorithm
        /// </summary>
        public void ShuffleDeck()
        {
            try
            {
                for (int i = 0; i < deck.Length; i++)
                {
                    int i_random = random.Next(i, deck.Length);
                    Card temp = deck[i_random];
                    deck[i_random] = deck[i];
                    deck[i] = temp;
                }
            }
            catch
            {
                Console.WriteLine("An issue occured while shuffling.. please try restarting the game!");
            }
        }

        /// <summary>
        /// Pops the last item from the array of cards and reduces array length by 1
        /// </summary>
        public void PlayCard()
        {
            try
            {
                // prints the last item of the array and ask user to choose again
                Console.WriteLine($"\n { Constants.playedCard}  { deck[deck.Length - 1].value } {deck[deck.Length - 1].suit} \n { Constants.userTurn}");

                Array.Resize(ref deck, deck.Length - 1);
            }
            catch
            {
                Console.WriteLine("An error occured while displaying your card!! Please try restarting the game..");
            }
        }

    }
}
