using System;
using System.Collections.Generic;


namespace Tic_Tac_Toe_Games
{
    public class UIGame
    {
        private const char X_PLAYER = 'X';
        private const char O_PLAYER = 'O';
        private const int GRID_SIZE = 3;
        private static int rows;
        private static int columns;
        private static char userSymbol;
        
      
        public static char ChooseSymbol()
        {
            while (true)
            {
                Console.WriteLine($"Choose your symbol {X_PLAYER} OR {O_PLAYER} : ");
                userSymbol = char.ToUpper(Console.ReadLine()[0]);
                if (userSymbol == X_PLAYER || userSymbol == O_PLAYER)
                {
                    return userSymbol;

                }
                Console.WriteLine($"Invalid symbol. Please choose {X_PLAYER} OR {O_PLAYER}");
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


       
    }

}

