



namespace Tic_Tac_Toe_Games
{

    public static class GameCodes
    {
        private const int GRID_SIZE = 3;
        private const int MAX_SIZE = 3;
        private static char userSymbol;
        private static char AiSymbol;
        private const int MIN_SIZE = 0;
        private const char EMPTY_SYMBOL = ' ';
        private static char firstSymbol;
        private static char[,] grid = new char[GRID_SIZE, GRID_SIZE];
        private static Random random = new Random();
        private static int rows;
        private static int columns;
        private static int winner;


        public static void ResetGrid()
        {
            for (int column = 0; column < GRID_SIZE; column++)
            {
                for (int rows = 0; rows < GRID_SIZE; rows++)
                {
                    grid[column, rows] = EMPTY_SYMBOL;
                }
            }
        }
        public static void ChosePlayerSymbols(char symbol)
        {
            userSymbol = symbol;
            AiSymbol = (symbol == 'X') ? 'O' : 'X';
        }

        public static void DisplayGrid()
        {
            for (rows = 0; rows < GRID_SIZE; rows++)
            {
                for (columns = 0; columns < GRID_SIZE; columns++)
                {
                    Console.Write(grid[rows, columns]);
                    if (columns < GRID_SIZE - 1) Console.Write("  |");
                }
                Console.WriteLine();
                if (rows < GRID_SIZE - 1) Console.WriteLine(" ----------- ");
            }
        }
        public static void ATMove()
        {
            while (true)
            {
                rows = random.Next(GRID_SIZE);
                columns = random.Next(GRID_SIZE);
                if (grid[rows, columns] == EMPTY_SYMBOL)
                {
                    grid[rows, columns] = AiSymbol;
                    break;
                }
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
    

        

        public static bool IsRowsWinning(int rows)
        {


            firstSymbol = grid[rows, 0];
            if (firstSymbol == EMPTY_SYMBOL)
            {
                return false;
            }
            for (columns = 1; columns < GRID_SIZE; columns++)
            {
                if (grid[rows, columns] != EMPTY_SYMBOL)
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
            foreach (char cell in grid)
            {
                if (cell == EMPTY_SYMBOL)
                {
                    return false;
                }

            }
            return true;
        }
        public static void PlayerMove()
        {
            while (true)
            {
                Console.WriteLine("Enter your move (rows and columns): ");

                rows = int.Parse(Console.ReadLine());
                columns = int.Parse(Console.ReadLine());
                if (rows >= 0 && rows < GRID_SIZE && columns >= 0 && columns < GRID_SIZE && grid[rows, columns] == EMPTY_SYMBOL)
                {
                    grid[rows, columns] = userSymbol;
                    break;


                    Console.WriteLine("Invalid move. Try again.");
                }
            }
        }


    }


}

