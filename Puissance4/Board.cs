using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Puissance4
{
    class Board
    {
        char[,] board = new char[8, 10];
        int choice, win;
        int myRow, turn = 0;
        public Board(Player player1, Player player2)
        {
            Console.Clear();
            Console.WriteLine("La partie commence !\n");
            Display.DisplayBoard(board);
            while (turn<42)
            {
                choice = Display.PlayerChoice(board, player1);
                myRow=BoardPos(player1, choice);
                turn += 1;
                Console.Clear();
                win = BoardWin(player1, myRow, choice);
                Display.DisplayBoard(board);
                if (win == 1)
                {
                    Display.PlayerWin(player1);
                    Display.restart(board);
                }

                choice = Display.PlayerChoice(board, player2);
                myRow = BoardPos(player2, choice);
                win = BoardWin(player2, myRow, choice);
                turn += 1;
                Console.Clear();
                Display.DisplayBoard(board);
                if (win == 1)
                {
                    Display.PlayerWin(player2);
                    Display.restart(board);
                }
            }
            Console.WriteLine("Egalité !!");
            Display.restart(board);
        }

        public int BoardPos(Player player, int choice)
        {
            int memRow = 6;

            while (true)
            {
                if (board[memRow, choice] != 'X' && board[memRow, choice] != 'O')
                {
                    board[memRow, choice] = player.ID;
                    break;
                }
                else
                {
                    memRow = memRow - 1;
                }
            }
            return memRow;
        }

        public int BoardWin(Player player, int row, int choice)
        {
            int memLig = row;
            int memCol = choice;
            int colWin = 0;
            int ligWin = 0;
            int dia1Win = 0;
            int dia2Win = 0;

            /** Victoire d'un joueur sur une colonne */
            while (board[memLig + 1, choice] == player.ID)
            {
                colWin++;
                memLig++;
            }
            memLig = row;
            while (board[memLig - 1, choice] == player.ID)
            {
                memLig--;
                colWin++;
            }
            memLig = row;
            if (colWin+1 >= 4)
            {
                return 1;
            }

            /** Victoire d'un joueur sur une ligne */
            while (board[row, memCol+1] == player.ID)
            {
                ligWin++;
                memCol++;
            }
            memCol = choice;
            while (board[row, memCol-1] == player.ID)
            {
                memCol--;
                ligWin++;
            }
            memCol = choice;
            if (ligWin + 1 >= 4)
            {
                return 1;
            }

            /** Victoire d'un joueur sur une diagonale */
            while (board[memLig + 1, memCol + 1] == player.ID)
            {
                dia1Win++;
                memLig++;
                memCol++;
            }
            memLig = row;
            memCol = choice;
            while (board[memLig - 1, memCol - 1] == player.ID)
            {
                memCol--;
                memLig--;
                dia1Win++;
            }
            memLig = row;
            memCol = choice;
            if (dia1Win + 1 >= 4)
            {
                return 1;
            }

            while (board[memLig - 1, memCol + 1] == player.ID)
            {
                memCol++;
                memLig--;
                dia2Win++;
            }
            memLig = row;
            memCol = choice;
            while (board[memLig + 1, memCol - 1] == player.ID)
            {
                memCol++;
                memLig--;
                dia2Win++;
            }
            memLig = row;
            memCol = choice;
            if (dia2Win+1 >= 4)
            {
                return 1;
            }
            return 0;
        }
    }
}