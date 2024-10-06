


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


        public static char[,] ResetGameBoard()
        {
            char[,] newGrid = new char[GameElement.GRID_SIZE, GameElement.GRID_SIZE];
            availableCells.Clear();
            for (int row = 0; row < GameElement.GRID_SIZE; row++)
            {
                for (int col = 0; col < GameElement.GRID_SIZE; col++)
                {
                    newGrid[row, col] = GameElement.EMPTY_SYMBOL;
                    availableCells.Add(new Cell(row, col));
                }
            }
            return newGrid;
        }
        public static void ChosePlayerSymbols(char symbol)
        {
            userSymbol = symbol;
            AiSymbol = (symbol == GameElement.X_PLAYER) ? GameElement.O_PLAYER : GameElement.X_PLAYER;
        }


        public static bool PlaceAIMove(char[,] grid)
        {
            if (availableCells.Count > 0)
            {
                int randomIndex = random.Next(availableCells.Count);

                Cell cell = availableCells[randomIndex];
                if (grid[cell.Row,cell.Col] == GameElement.EMPTY_SYMBOL)
                {
                grid[cell.Row,cell.Col] = AiSymbol;
                availableCells.RemoveAt(randomIndex);

                    return true;
                }

            }
            return false;
        }
        public static char[,] PlacePlayerMove(char[,] grid ,Cell move)
        {

            char[,] updatedGrid = (char[,])grid.Clone();
            if (updatedGrid[move.Row, move.Col] == GameElement.EMPTY_SYMBOL)
            {
                updatedGrid[move.Row, move.Col] = userSymbol;
                availableCells.Remove(move);
                return updatedGrid;
            }
            else
            {
                return grid;
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
        public static GameStatus CheckGameOver(char[,] grid)
        {
           
            if (IsGridFull(grid))
            {
                return GameStatus.Draw;
            }

           
            Players winner = CheckWinner(grid);
            
            if (winner == Players.User)
            {
                return GameStatus.PlayWins;
            }
            if (winner == Players.AI)
            {
                return GameStatus.AIWins;
            }

            return GameStatus.Continue;  

        }
       

    }


}




