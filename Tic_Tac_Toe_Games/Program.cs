using Tic_Tac_Toe_Games;

namespace Tic_Tac_teo_GPT
{
    public class Program
    {
        static void Main(string[] args)
        {

            char[,] grid = GameCodes.ResetGameBoard();
            char playSymbol = UIGame.ChooseSymbol();
            GameCodes.AssignPlayerSymbols(playSymbol);
            Cell playMove;

            while (true)
            {
                UIGame.DisplayGrid(grid);
                bool isValidMove = false;
                while (!isValidMove)
                {
                    playMove = UIGame.GetPlayerMove(GameConstants.GRID_SIZE);
                    char[,] newGrid = GameCodes.PlacePlayerMove(grid, playMove);

                    if (newGrid != grid)

                    {
                        grid = newGrid;
                        isValidMove = true;
                    }
                    else
                    {
                        UIGame.PrintInvalidCell();
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
                    UIGame.PrintAIMoveError();
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


