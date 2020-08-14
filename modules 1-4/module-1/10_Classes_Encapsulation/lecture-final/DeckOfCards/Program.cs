using System;
using System.Collections.Generic;
using DeckOfCards.Classes;

namespace DeckOfCards
{
    class Program
    {
        static void Main(string[] args)
        {
            Deck deck = new Deck();

            while (true)
            {
                Console.WriteLine("What do you want to do? ");
                Console.WriteLine("2. Display all of the cards.");
                Console.WriteLine("3. Flip all of the cards.");
                Console.WriteLine("4. Shuffle");
                Console.WriteLine("Q. Quit");

                string input = Console.ReadLine();

                if (input == "2")
                {
                    Console.WriteLine("Displaying all of the cards.");

                    // Loop through each of the cards
                    Card[] cards = deck.GetCards();

                    foreach (Card card in cards)
                    {
                        if (card.IsFaceUp)
                        {
                            Console.WriteLine($"CARD: {card.Value} of {card.Suit}");
                        }
                        else
                        {
                            Console.WriteLine($"CARD: XXXX");
                        }
                    }
                }
                else if (input == "3")
                {
                    Console.WriteLine($"Flipping the cards.");

                    // Loop through each of the cards and flip them
                    Card[] cards = deck.GetCards();
                    foreach (Card card in cards)
                    {
                        if (card.IsFaceUp)
                        {
                            Console.WriteLine($"Flipping {card.Value} of {card.Suit} down.");
                        }
                        else
                        {
                            Console.WriteLine($"Flipping {card.Value} of {card.Suit} up.");
                        }

                        card.Flip();
                    }
                }
                else if (input == "4")
                {
                    deck.Shuffle();
                    Console.WriteLine("Deck shuffled");
                }
                else if (input == "Q")
                {
                    break;
                }

                // Wait for user to press enter and clear screen.
                Console.ReadLine();
                Console.Clear();
            }
        }
    }
}
