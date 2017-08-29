using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module14
{
    class Card
    {
        public int cardType { get; set; }//старшинство
        public int cardSuit { get; set; }//масть
        public Card() { }
        public Card(int cardType, int cardSuit)
        {
            this.cardSuit = cardSuit;
            this.cardType = cardType;
        }
        public List<Card> giveCards()//новые, разложенные по порядку :p
        {
            List<Card> cards = new List<Card>();
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 9; j++)
                    cards.Add(new Card(i,j));
            return cards;
        }
    }
}
