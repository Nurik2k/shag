using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Durak.BLL
{
    public enum Suit { Diamonds, Hearts, Clubs, Spades}
    public class Card
    {
        public Suit CardSuit { get; set; }
        public int CardNumber { get; set; }
        public bool IsTrump { get; set; } = false;
        public Card(Suit cardSuit, int cardNumber)
        {
            CardSuit = cardSuit;
            CardNumber = cardNumber;
        }  
    }
}
