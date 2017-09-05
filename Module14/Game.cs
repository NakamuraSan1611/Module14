using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module14
{
    
    

    class Game
    {
        public static IComparer sortYearAscending()
        {
            return (IComparer)new Player();
        }
        private class GameComparer : IComparer
        {
            int IComparer.Compare(object a, object b)
            {
                Player c1 = (Player)a;
                Player c2 = (Player)b;
                return String.Compare(c2.name, c1.name);
            }
            
        }
        public SortedDictionary<Player, List<Card>> startGame(int players)
        {
            // Dictionary<Player, List<Card>> team = new Dictionary<Player, List<Card>>();
            CultureInfo myCul = new CultureInfo("tr-TR");
            SortedDictionary<Player, List<Card>> team = new SortedDictionary<Player, List<Card>>(new GameComparer());
            List<Player> qwe = new List<Player>();
            List<List<Player>> qwerty = new List<List<Player>>();
            
            Card card = new Card();
            List<Card> cards = card.giveCards();
            cards = cards.OrderBy(a => Guid.NewGuid()).ToList();
            int count = 0;
            for (int i = 1; i <= players; i++)
            {
                Player player = new Player();
                player.name = "player " + i;

                List<Card> playerCards = new List<Card>();
                for (int j = 0; j < 36 / players; j++)
                    playerCards.Add(cards[count++]);
                
                team.Add(player, playerCards);
            }
            return team;
        }
        public void playGame(SortedDictionary<Player, List<Card>> team)
        {
            bool endgame = true;
            int round = 0;
            int[] findMaxCardtemp = new int[team.Count];
            List<Card> findMaxCard = new List<Card>();
            
            while (endgame)
            {
                foreach (var item in team)
                {
                    Console.Write(item.Key.name + "\t");
                    foreach (var card in item.Value)
                    {
                        Console.Write(card.cardSuit + " ");
                    }
                    Console.WriteLine();
                }
                int i = 0;
                foreach (var item in team)
                {
                    //                    if(item.Value.Capacity != 0)
                    findMaxCard.Add(item.Value[i]);//карты могут закончится раньше игры
                    item.Value.Remove(item.Value[i]);

                }
                //     int roundWinner = findMaxCard.IndexOf(findMaxCard.Max());
                var winner = team.First(x => x.Value[i].cardSuit == findMaxCard.Max(y => y.cardSuit));
                var loser = team.First(x => x.Value.Capacity == 0);

                //team.Remove(loser.Key);
                winner.Value.AddRange(findMaxCard);
                findMaxCard.Clear();
                if (team.Count == 1)
                    endgame = false;
                i++;
            }
        }
    }
}
