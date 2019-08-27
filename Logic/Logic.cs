using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class Deck
    {
        private Card[] deck;
        private int current_card;
        private int number_of_cards;
        private Random random_number;
        string[] value_32 = { "Seven", "Eight", "Nine", "Ten",
                               "Jack", "Queen", "King", "Ace" };
        string[] value_52 = { "Ace", "Two", "Three", "Four", "Five",
                               "Six", "Seven", "Eight", "Nine", "Ten",
                               "Jack", "Queen", "King" };
        string[] suits = { "Hearts", "Clubs", "Diamonds", "Spades" };

        public Deck(int deck_size)
        {
            number_of_cards = deck_size;
            deck = new Card[number_of_cards];
            current_card = 0;
            random_number = new Random();
            if (number_of_cards == 52) {
                for (int i = 0; i < deck.Length; i++) {
                    deck[i] = new Card(value_52[i % 13], suits[i / 13]);
                }
            } else {
                for (int i = 0; i < deck.Length; i++) {
                    deck[i] = new Card(value_32[i % 8], suits[i / 8]);
                }
            }
            
        }

        public void Shuffle()
        {
            current_card = 0;
            for (int i = deck.Length - 1; i > 0; i--)
            {
                int next_card = random_number.Next(i + 1);
                Card temporary_card = deck[i];
                deck[i] = deck[next_card];
                deck[next_card] = temporary_card;
            }
        }

        public Card ShowCards()
        {
            if (current_card < deck.Length)
                return deck[current_card++];
            else 
                return null;
        }
    }
}
