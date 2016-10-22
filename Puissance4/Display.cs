using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Puissance4
{
    class Display
    {
        public static int PlayerChoice(char[,] board, Player activePlayer)
        {
            int choice;

            Console.WriteLine("\n"+activePlayer.Name + " à vous ! ");
            Console.WriteLine("Numéro de 1 à 7 : ");
            choice = int.Parse(Console.ReadLine());
            while (choice < 1 || choice > 7)
            {
                Console.WriteLine("Erreur, numéro de 1 à 7 :");
                choice = int.Parse(Console.ReadLine());
            }
            while (board[1, choice] == 'X' || board[1, choice] == 'O')
            {
                Console.WriteLine("Ligne pleine. Numéro de 1 à 7 : ");
                choice = int.Parse(Console.ReadLine());
            }
            return choice;
        }

        public static Player Player1()
        {
            Console.WriteLine("Bienvenue sur le puissance 4.\n");

            Console.WriteLine("Nom du joueur 1 : ");
            String name1 = Console.ReadLine();
            char ID1 = 'X';

            Player player1 = new Player(name1, ID1);
            return player1;
        }

        public static Player Player2()
        {
            Console.WriteLine("\nNom du joueur 2 : ");
            String name2 = Console.ReadLine();
            char ID2 = 'O';

            Player player2 = new Player(name2, ID2);
            return player2;
        }

        public static void restart(char[,] board)
        {
            int restart;
            Console.WriteLine("Voulez-vous rejouer ? Oui(1) Non(2): ");
            restart = int.Parse(Console.ReadLine());
            if (restart == 1)
            {
                System.Diagnostics.ProcessStartInfo myInfo = new System.Diagnostics.ProcessStartInfo();
                myInfo.FileName = "Puissance4.exe";
                System.Diagnostics.Process.Start(myInfo);
                Environment.Exit(0);
            }
            else
            {
                Console.WriteLine("Au revoir !");
                Environment.Exit(0);
            }
        }

        public static void PlayerWin(Player actualPlayer)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\n"+actualPlayer.Name + " a gagné.");
        }

        public static void DisplayBoard(char[,] board)
        {
            int i, ix;
            int memRow = 6;
            int memCol = 7;

            for (i = 1; i <= memRow; i++)
            {
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write("|");
                for (ix = 1; ix <= memCol; ix++)
                {
                    if (board[i, ix] != 'X' && board[i, ix] != 'O')
                    {
                        Console.ForegroundColor = ConsoleColor.Gray;
                        //board[i, ix] = '■';
                    }
                    if (board[i, ix] == 'X')
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                    }
                    if (board[i, ix] == 'O')
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                    }
                    Console.Write(board[i, ix]);
                }
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write("| \n");
            }
            Console.Write(" 1234567");

        }
    }
}
