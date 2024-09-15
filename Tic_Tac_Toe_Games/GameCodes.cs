


namespace Tic_Tac_Toe_Games
{

    public static class GameCodes
    {

        private static char userSymbol;
        private static char AiSymbol;
        private static char firstSymbol;
        private static Random random = new Random();
        private static int winner;
        private static List<Cell> availableCells = new List<Cell>();


        public static void ResetGrid(char[,] grid)
        {
            availableCells.Clear();
            for (int row = 0; row < GameElement.GRID_SIZE; row++)
            {
                for (int col = 0; col < GameElement.GRID_SIZE; col++)
                {
                    grid[row, col] = GameElement.EMPTY_SYMBOL;
                    availableCells.Add(new Cell(row, col));
                }
            }
        }
        public static void ChosePlayerSymbols(char symbol)
        {
            userSymbol = symbol;
            AiSymbol = (symbol == GameElement.X_PLAYER) ? GameElement.O_PLAYER : GameElement.X_PLAYER;
        }


        public static void AIMove(char[,] grid)
        {
            if (availableCells.Count > 0)
            {
                int randomIndex = random.Next(availableCells.Count);

                Cell cell = availableCells[randomIndex];
                if (grid[cell.Row,cell.Col] == GameElement.EMPTY_SYMBOL)
                {
                grid[cell.Row,cell.Col] = AiSymbol;

                availableCells.RemoveAt(randomIndex);

                }

            }

        }
        public static void PlayerMove(char[,] grid)
        {
            Cell move = GetPlayerMove(GameElement.GRID_SIZE);

            if (grid[move.Row,move.Col] == GameElement.EMPTY_SYMBOL)
            {
                grid[move.Row,move.Col] = userSymbol;
                availableCells.Remove(move);
            }
            else
            {
                Console.WriteLine("This cell is already taken! Please choose another.");
                PlayerMove(grid); 
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
        public static Players CheckWinner(char[,] grid)
        {

            for (winner = 0; winner < GameElement.GRID_SIZE; winner++)
            {
                if (IsRowsWinning(grid, winner))
                {
                    return (grid[winner, 0] == userSymbol) ? Players.User : Players.AI;

                }
                if (IsColumnWinning(grid, winner))
                {
                    return (grid[0, winner] == userSymbol) ? Players.User : Players.AI;
                }
            }
            if (IsDiagonalWinning(grid))
            {
                return (grid[0, 0] == userSymbol) ? Players.User : Players.AI;
            }
            if (IsRichtDiagonalWinning(grid))
            {

                return (grid[0, GameElement.GRID_SIZE - 1] == userSymbol) ? Players.User : Players.AI;

            }

            return Players.None;
        }

        public static bool IsGridFull(char[,] grid)
        {
            foreach (char cell in grid)
            {
                if (cell ==GameElement.EMPTY_SYMBOL) return false;
            }
            return true;
        }

        public static bool IsRowsWinning(char[,] grid, int row)
        {


            firstSymbol = grid[row, 0];
            if (firstSymbol == GameElement.EMPTY_SYMBOL)
            {
                return false;
            }
            for (int col = 1; col < GameElement.GRID_SIZE; col++)
            {
                if (grid[row, col] != firstSymbol)
                {
                    {
                        return false;
                    }

                }
            }
            return true;
        }

        public static bool IsColumnWinning(char[,] grid, int col)
        {
            firstSymbol = grid[0, col];

            if (firstSymbol == GameElement.EMPTY_SYMBOL)
            {
                return false;
            }

            for (int row = 1; row < GameElement.GRID_SIZE; row++)
            {
                if (grid[row, col] != firstSymbol)
                {
                    return false;
                }
            }
            return true;
        }

        public static bool IsDiagonalWinning(char[,] grid)
        {
            firstSymbol = grid[0, 0];
            if (firstSymbol == GameElement.EMPTY_SYMBOL)
            {
                return false;
            }

            for (int i = 1; i < GameElement.GRID_SIZE; i++)

            {
                if (grid[i, i] != firstSymbol)
                {

                    return false;
                }

            }
            return true;
        }

        public static bool IsRichtDiagonalWinning(char[,] grid)
        {
            firstSymbol = grid[0, GameElement.GRID_SIZE - 1];
            if (firstSymbol == GameElement.EMPTY_SYMBOL)
            {
                return false;
            }
            for (int i = 1; i < GameElement.GRID_SIZE; i++)
            {
                if (grid[i, GameElement.GRID_SIZE - 1 - i] != firstSymbol)
                {
                    return false;
                }

            }
            return true;
        }

    }


}




