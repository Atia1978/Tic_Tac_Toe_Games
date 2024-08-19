using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Tic_Tac_Toe_Games
{
    public class UIGame
    {
        private const char X_PLAYER = 'X';
        private const char O_PLAYER = 'O';
        private static char userSymbol;
        public static void StartGame()
        {
            GameCodes.ResetGrid();
            while (true)
            {
                Console.WriteLine("Choose your symbol (X or O): ");
                userSymbol = char.ToUpper(Console.ReadLine()[0]);
                if (userSymbol == X_PLAYER || userSymbol == O_PLAYER)
                {
                    break;

                }
                Console.WriteLine("Invalid symbol. Please choose X or O.");
            }

            GameCodes.ChosePlayerSymbols(userSymbol);

            while (true)
            {
                DisplayGrid(GameCodes.grid);
                GameCodes.PlayerMove();
                GameCodes.AIMove();

                Players winner = GameCodes.CheckWinner();
                if (winner != Players.None)
                {
                    DisplayGrid(GameCodes.grid);
                    Console.WriteLine($"{winner} wins!");
                    break;
                }

                if (GameCodes.IsGridFull())
                {
                    DisplayGrid(GameCodes.grid);
                    Console.WriteLine("It's a draw!");
                    break;
                }
            }
        }
        
        public static void DisplayGrid(char[,] grid)
        {
            int gridSize = grid.GetLength(0);
            for (int row = 0; row < gridSize; row++)
            {
                for (int col = 0; col < gridSize; col++)
                {
                    Console.Write(grid[row, col]);
                    if (col < gridSize - 1) Console.Write("  |");
                }
                Console.WriteLine();
                if (row < gridSize - 1) Console.WriteLine(" ----------- ");
            }
        }

        public static (int row, int col) GetPlayerMove(int gridSize)
        {
            while (true)
            {
                Console.WriteLine("Enter your move (row and column): ");
                int row = int.Parse(Console.ReadLine());
                int col = int.Parse(Console.ReadLine());

                if (row >= 0 && row < gridSize && col >= 0 && col < gridSize)
                {
                    return (row, col);
                }
                else
                {
                    Console.WriteLine("Invalid move. Try again.");
                }
            }

        }
    }
}

