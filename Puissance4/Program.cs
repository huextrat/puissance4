using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Puissance4
{
    class Program
    {
        static void Main(string[] args)
        {
                Player player1 = Display.Player1();
                Player player2 = Display.Player2();
                Board board = new Board(player1, player2);
        }

        
    }
}
