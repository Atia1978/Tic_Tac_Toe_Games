using Tic_Tac_Toe_Games;

namespace Tic_Tac_teo_GPT
{
    internal class Program
    {
        private static char playSymbol;
        private const int GRID_SIZE = 3;
        public static char[,] grid = new char[GameElement.GRID_SIZE, GameElement.GRID_SIZE];
        static void Main(string[] args)
        {
            grid = GameCodes.ResetGameBoard();
            playSymbol = UIGame.ChooseSymbol();
            GameCodes.ChosePlayerSymbols(playSymbol);
            Cell playMove;

            while (true)
            {
                UIGame.DisplayGrid(grid);
                bool isValidMove = false;
                while (!isValidMove)
                {
                    playMove = UIGame.GetPlayerMove(GameElement.GRID_SIZE);
                    if (GameCodes.PlacePlayerMove(grid, playMove))
                    {
                        isValidMove = true;
                    }
                    else
                    {
                        UIGame.ShowMessage("This cell is already taken! Please choose another.");
                    }
                }
                GameStatus status = GameCodes.CheckGameOver(grid);
                if (status != GameStatus.Continue)
                {
                    UIGame.DisplayGrid(grid);
                    UIGame.DisplayGameStatus(status);
                    break;
                }
                if (!GameCodes.PlaceAIMove(grid))
                {
                    UIGame.ShowMessage("AI was unable to make a move.");
                    break;
                }
                status = GameCodes.CheckGameOver(grid);
                if (status != GameStatus.Continue)
                {
                    UIGame.DisplayGrid(grid);
                    UIGame.DisplayGameStatus(status);
                    break;
                }
            }
        }
        
    }

}


