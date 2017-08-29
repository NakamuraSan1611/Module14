using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module14
{
    class Player
    {
//        public List<Card> playerCards = new List<Card>();
        public string name { get; set; }
        public int getCards(List<Card> playerCards)
        {
            return playerCards.Count;
        }


    }
}
