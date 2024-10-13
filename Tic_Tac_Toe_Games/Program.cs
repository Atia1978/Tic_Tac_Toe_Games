using Tic_Tac_Toe_Games;

namespace Tic_Tac_teo_GPT
{
    public class Program
    {  
        static void Main(string[] args)
        {
            char playSymbol;
            char[,] grid = new char[GameElement.GRID_SIZE, GameElement.GRID_SIZE];
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
                    char[,]newGrid = GameCodes.PlacePlayerMove(grid,playMove);
                    if (newGrid!=grid)
                    {
                        grid = newGrid;
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


