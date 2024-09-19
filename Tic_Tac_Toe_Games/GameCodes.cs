


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


        public static void ResetGameBoard(char[,] grid)
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


        public static void PlaceAIMove(char[,] grid)
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
        public static void PlacePlayerMove(char[,] grid)
        {
            Cell move = UIGame.GetPlayerMove(GameElement.GRID_SIZE);

            if (grid[move.Row,move.Col] == GameElement.EMPTY_SYMBOL)
            {
                grid[move.Row,move.Col] = userSymbol;
                availableCells.Remove(move);
            }
            else
            {
                UIGame.ShowMessage("This cell is already taken! Please choose another.");
                PlacePlayerMove(grid); 
            }
        }
        
        public static Players CheckWinner(char[,] grid)
        {

            for (winner = 0; winner < GameElement.GRID_SIZE; winner++)
            {
                if (CheckRowForWin(grid, winner))
                {
                    return (grid[winner, 0] == userSymbol) ? Players.User : Players.AI;

                }
                if (CheckColumnForWin(grid, winner))
                {
                    return (grid[0, winner] == userSymbol) ? Players.User : Players.AI;
                }
            }
            if (CheckMainDiagonalForWin(grid))
            {
                return (grid[0, 0] == userSymbol) ? Players.User : Players.AI;
            }
            if (CheckAntiDiagonalForWin(grid))
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

        public static bool CheckRowForWin(char[,] grid, int row)
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

        public static bool CheckColumnForWin(char[,] grid, int col)
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

        public static bool CheckMainDiagonalForWin(char[,] grid)
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

        public static bool CheckAntiDiagonalForWin(char[,] grid)
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




