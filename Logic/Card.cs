using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class Card
    {
        private string value;
        private string suit;

        public Card(string card_value, string card_suit)
        {
            value = card_value;
            suit = card_suit;
        }

        public override string ToString()
        {
            return "  => " + value + " of " + suit;
        }
    }
}
