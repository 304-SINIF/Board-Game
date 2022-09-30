using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Board.Example
{
    internal class Program
    {
        const int ROW = 4;
        const int COL = 4;
        static void Main(string[] args)
        {
            string[,] board = new string[ROW, COL];
            
            Random r = new Random();
            int startingRow = r.Next(0, ROW);
            int startingCol = r.Next(0, COL);

            ConsoleKeyInfo[] keys = new ConsoleKeyInfo[3];
            int i = 0;
            while (i < 3)
            {
                keys[i] = Console.ReadKey();
                i++;
            }

            int currentRow = startingRow;
            int currentCol = startingCol;
            for (int j = 0; j < keys.Length; j++)
            {
                var key = keys[j];
                int index = 0;
                switch (key.Key)
                {
                    case ConsoleKey.UpArrow:
                        index = currentRow - 1;
                        currentRow = index == -1 ? ROW - 1 : index;
                        break;
                    case ConsoleKey.DownArrow:
                        index = currentRow + 1;
                        currentRow = index == ROW ? 0 : index;
                        break;
                    case ConsoleKey.LeftArrow:
                        index = currentCol - 1;
                        currentCol = index == -1 ? COL - 1 : index;
                        break;
                    case ConsoleKey.RightArrow:
                        index = currentCol + 1;
                        currentCol = index == COL ? 0 : index;
                        break;

                    default: break;
                }
            }

            FillBoard(board, currentRow, currentCol);
            PrintBoard(board);

            int guessedRow = int.Parse(Console.ReadLine());
            int guessedCol = int.Parse(Console.ReadLine());

            if (guessedRow == startingRow && guessedCol == startingCol)
            {
                Console.WriteLine("Tebrikler");
            }
            else
            {
                Console.WriteLine("Rezillik");
            }
            Console.ReadKey();
        }

        static void FillBoard(string[,] board, int filledRow, int filledCol)
        {
            for (int i = 0; i < ROW; i++)
            {
                for (int j = 0; j < COL; j++)
                {
                    if (i == filledRow && j == filledCol)
                    {
                        board[i, j] = "x";
                        continue;
                    }
                    board[i, j] = "-";
                }
            }
        }

        static void PrintBoard(string[,] board)
        {
            Console.Clear();
            Console.WriteLine();
            for (int i = 0; i < ROW; i++)
            {
                for (int j = 0; j < COL; j++)
                {
                    Console.Write(board[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
}
