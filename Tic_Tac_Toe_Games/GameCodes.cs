


namespace Tic_Tac_Toe_Games
{

    public static class GameCodes
    {
        private const int GRID_SIZE = 3;
        private const int MAX_SIZE = 3;
        private const char X_PLAYER = 'X';
        private const char O_PLAYER = 'O';
        private const int MIN_SIZE = 0;
        private static char userSymbol;
        private static char AiSymbol;
        private const char EMPTY_SYMBOL = ' ';
        private static char firstSymbol;
        
        private static Random random = new Random();
        private static int rows;
        private static int columns;
        private static int winner;
        private static int randomIndex;
        private static List<Cell> availableCells = new List<Cell>();


        public static void ResetGrid(char[,] grid)
        {
            availableCells.Clear();
            for (rows = 0; rows < GRID_SIZE; rows++)
            {
                for (columns = 0; columns < GRID_SIZE; columns++)
                {
                    grid[rows, columns] = EMPTY_SYMBOL;
                    availableCells.Add(new Cell(rows, columns));
                }
            }
        }
        public static void ChosePlayerSymbols(char symbol)
        {
            userSymbol = symbol;
            AiSymbol = (symbol == X_PLAYER) ? O_PLAYER : X_PLAYER;
        }


        public static void AIMove(char[,] grid)
        {
            if (availableCells.Count > 0)
            {
                randomIndex = random.Next(availableCells.Count);

                Cell cell = availableCells[randomIndex];
                rows = cell.Rows;
                columns = cell.Columns;

                grid[rows, columns] = AiSymbol;
                availableCells.RemoveAt(randomIndex);
            }

        }

        public static void PlayerMove(char[,] grid)
        {
            (rows, columns) = GetPlayerMove(GRID_SIZE);
            if (grid[rows, columns] == EMPTY_SYMBOL)
            {
                grid[rows, columns] = userSymbol;
                availableCells.Remove(new Cell(rows, columns));
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

        public static Players CheckWinner(char[,] grid)
        {

            for (winner = 0; winner < GRID_SIZE; winner++)
            {
                if (IsRowsWinning(grid,winner))
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

                return (grid[0, GRID_SIZE - 1] == userSymbol) ? Players.User : Players.AI;

            }

            return Players.None;
        }

        public static bool IsGridFull(char[,] grid)
        {
            foreach (char cell in grid)
            {
                if (cell == EMPTY_SYMBOL) return false;
            }
            return true;    
        }

        public static bool IsRowsWinning(char[,] grid, int row)
        {


            firstSymbol = grid[row, 0];
            if (firstSymbol == EMPTY_SYMBOL)
            {
                return false;
            }
            for (columns = 1; columns < GRID_SIZE; columns++)
            {
                if (grid[row, columns] != firstSymbol)
                {
                    {
                        return false;
                    }

                }
            }
            return true;
        }

        public static bool IsColumnWinning(char[,] grid, int column)
        {
            firstSymbol = grid[0, column];

            if (firstSymbol == EMPTY_SYMBOL)
            {
                return false;
            }

            for (int rows = 1; rows < GRID_SIZE; rows++)
            {
                if (grid[rows, column] != firstSymbol)
                {
                    return false;
                }
            }
            return true;
        }

        public static bool IsDiagonalWinning(char[,] grid)
        {
            firstSymbol = grid[0, 0];
            if (firstSymbol == EMPTY_SYMBOL)
            {
                return false;
            }

            for (int i = 1; i < GRID_SIZE; i++)

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
            firstSymbol = grid[0, GRID_SIZE - 1];
            if (firstSymbol == EMPTY_SYMBOL)
            {
                return false;
            }
            for (int i = 1; i < GRID_SIZE; i++)
            {
                if (grid[i, GRID_SIZE - 1 - i] != firstSymbol)
                {
                    return false;
                }

            }
            return true;
        }

    }


}




