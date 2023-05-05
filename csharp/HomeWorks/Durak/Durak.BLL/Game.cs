using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Durak.BLL
{
    public class Game
    {
        public List<Card> CardDeck = new List<Card>();
        public List<Card> GetCardDeck()
        {
            foreach (var item in (Suit[])Enum.GetValues(typeof(Suit)))
            {
                for (int i = 6; i <= 14; i++)
                {
                    Card card = new Card(item, i);
                    card.CardNumber = i;
                    card.CardSuit = item;
                    this.CardDeck.Add(card);
                }
            }
            return this.CardDeck;
        }
        public void Distribution(List<Player> players)
        {
            List<Card> CardDeck =  GetCardDeck();
            int count = players.Count;
            int i = 0;
            foreach (Card item in CardDeck)
            {
                players[i].CardDeck.Add(item);
                
                if (i <= count) i++;
                else i = 0;
            }
        }
    }
}
