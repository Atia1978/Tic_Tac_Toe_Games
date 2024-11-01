namespace Tic_Tac_Toe_Games
{
    public class UIGame
    {
        private static char userSymbol;
        

        public static char ChooseSymbol()
        {
            while (true)
            {
                Console.WriteLine($"Choose your symbol {GameConstants.X_PLAYER} OR {GameConstants.O_PLAYER} : ");
                userSymbol = char.ToUpper(Console.ReadLine()[0]);
                if (userSymbol ==GameConstants.X_PLAYER || userSymbol ==GameConstants.O_PLAYER)
                {
                    return userSymbol;

                }
                Console.WriteLine($"Invalid symbol. Please choose {GameConstants.X_PLAYER} OR {GameConstants.O_PLAYER}");
            }
            
        }
            public static void DisplayGrid(char[,] grid)
            {
                int gridSize = GameConstants.GRID_SIZE;
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

        public static Cell GetPlayerMove(int gridSize)
        {
            Console.WriteLine("Please enter the row and column like ---> ('1,2') ");
            while (true)
            {
                string input = Console.ReadLine();
                string[] parts = input.Split(',');

                if (parts.Length == 2 &&
                    int.TryParse(parts[0].Trim(), out int row) &&
                    int.TryParse(parts[1].Trim(), out int col) &&
                    row >= 0 && row < gridSize &&
                    col >= 0 && col < gridSize)
                {
                    return new Cell(row, col);
                }
                else
                {
                    Console.WriteLine("Invalid move. Make sure to enter the row and column as numbers separated by a comma like ---> ('1,2').");
                }
            }
        }
        public static void DisplayGameStatus(GameStatus status)
        {
            switch (status)
            {
                case GameStatus.PlayWins:
                   Console.WriteLine("Play wins!");
                    break;
                case GameStatus.AIWins:
                    Console.WriteLine("AT wins!");
                    break;
                case GameStatus.Draw:
                    Console.WriteLine("It's a draw!");
                    break;
            }
        }
        public static void PrintInvalidCell()
        {
            Console.WriteLine("This cell is already taken! Please choose another.");
        }

        public static void PrintAIMoveError()
        {
            Console.WriteLine("AI was unable to make a move.");
        }

    }

}

