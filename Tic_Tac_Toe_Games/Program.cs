using Tic_Tac_Toe_Games;

namespace Tic_Tac_teo_GPT
{
    public class Program
    {
        static void Main(string[] args)
        {
            char userSymbol;
            char aisSymbol;
            char[,] grid = GameCodes.ResetGameBoard();
            char playSymbol = UIGame.ChooseSymbol();
            GameCodes.AssignPlayerSymbols(playSymbol,out userSymbol, out aisSymbol);
            Cell playMove;

            while (true)
            {
                UIGame.DisplayGrid(grid);
                bool isValidMove = false;
                while (!isValidMove)
                {
                    playMove = UIGame.GetPlayerMove(GameConstants.GRID_SIZE);
                    char[,] newGrid = GameCodes.PlacePlayerMove(grid, playMove,userSymbol);

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

                GameStatus status = GameCodes.CheckGameOver(grid,userSymbol);

                if (status != GameStatus.Continue)
                {
                    UIGame.DisplayGrid(grid);
                    UIGame.DisplayGameStatus(status);
                    break;
                }

                if (!GameCodes.PlaceAIMove(grid, aisSymbol))
                {
                    UIGame.PrintAIMoveError();
                    break;
                }

                status = GameCodes.CheckGameOver(grid, userSymbol);

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


