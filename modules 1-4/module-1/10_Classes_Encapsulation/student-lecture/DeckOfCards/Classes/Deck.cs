using System;
using System.Collections.Generic;
using System.Text;

namespace DeckOfCards.Classes
{
    class Deck
    {
        private List<Card> deck = new List<Card>();

        public Deck()
        {
            string[] suits = { "Spades", "Hearts", "Clubs", "Diamonds" };

            foreach(string suit in suits)
            {
                for(int i = 1; i <= 13; i++)
                {
                    Card card = new Card(i, suit);
                    deck.Add(card);
                }
            }
        }

        public Card[] GetCards()
        {
            Card[] cards = deck.ToArray();
            return cards;
        }

        public void Shuffle()
        {
            Random rnd = new Random();

            for (int i = 0; i < deck.Count; i++)
            {
                int j = rnd.Next(0, deck.Count);

                Card temp = deck[i];
                deck[i] = deck[j];
                deck[j] = temp;
            }
        }

    }

}
