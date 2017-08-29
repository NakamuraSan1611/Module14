using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Module14
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();
            Console.WriteLine("Введите количество игроков");
            Dictionary<Player, List<Card>> team = game.startGame(Convert.ToInt32(Console.ReadLine()));
            game.playGame(team);

        }
    }
}
