


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
        public static char[,] grid = new char[GRID_SIZE, GRID_SIZE];
        private static Random random = new Random();
        private static int rows;
        private static int columns;
        private static int winner;
        private static int randomIndex;
        private static List<Cell> availableCells = new List<Cell>();


        public static void ResetGrid()
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


        public static void AIMove()
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
        public static void PlayerMove()
        {
            (int row, int col) = UIGame.GetPlayerMove(GRID_SIZE);
            if (grid[row, col] == EMPTY_SYMBOL)
            {
                grid[row, col] = userSymbol;
                availableCells.Remove(new Cell(row, col));
            }
        }


        public static Players CheckWinner()
        {

            for (winner = 0; winner < GRID_SIZE; winner++)
            {
                if (IsRowsWinning(winner))
                {
                    return (grid[winner, 0] == userSymbol) ? Players.User : Players.AI;

                }
                if (IsColumnWinning(winner))
                {
                    return (grid[0, winner] == userSymbol) ? Players.User : Players.AI;
                }
            }
            if (IsDiagonalWinning())
            {
                return (grid[0, 0] == userSymbol) ? Players.User : Players.AI;
            }
            if (IsRichtDiagonalWinning())
            {

                return (grid[0, GRID_SIZE - 1] == userSymbol) ? Players.User : Players.AI;

            }

            return Players.None;
        }

        public static bool IsRowsWinning(int row)
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

        public static bool IsColumnWinning(int column)
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

        public static bool IsDiagonalWinning()
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

        public static bool IsRichtDiagonalWinning()
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
        public static bool IsGridFull()
        {

            return availableCells.Count == 0;
        }
       

    }


}




