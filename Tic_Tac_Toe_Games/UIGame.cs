using System;
using System.Collections.Generic;


namespace Tic_Tac_Toe_Games
{
    public class UIGame
    {
        private static char userSymbol;
        
      
        public static char ChooseSymbol()
        {
            while (true)
            {
                Console.WriteLine($"Choose your symbol {GameElement.X_PLAYER} OR {GameElement.O_PLAYER} : ");
                userSymbol = char.ToUpper(Console.ReadLine()[0]);
                if (userSymbol ==GameElement.X_PLAYER || userSymbol ==GameElement.O_PLAYER)
                {
                    return userSymbol;

                }
                Console.WriteLine($"Invalid symbol. Please choose {GameElement.X_PLAYER} OR {GameElement.O_PLAYER}");
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

