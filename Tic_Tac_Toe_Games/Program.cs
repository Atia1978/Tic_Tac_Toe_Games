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
            GameCodes.ResetGameBoard(grid);
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
            
                Players winner = GameCodes.CheckWinner(grid);
                if (winner != Players.None)
                {
                    UIGame.DisplayGrid(grid);
                    Console.WriteLine($"{winner} wins!");
                    break;
                }

                if (GameCodes.IsGridFull(grid))
                {
                    UIGame.DisplayGrid(grid);
                    Console.WriteLine("It's a draw!");
                    break;
                }
                GameCodes.PlaceAIMove(grid);

                winner = GameCodes.CheckWinner(grid);
                if (winner != Players.None)
                {
                    UIGame.DisplayGrid(grid);
                    Console.WriteLine($"{winner} wins!");
                    break;
                }

                if (GameCodes.IsGridFull(grid))
                {
                    UIGame.DisplayGrid(grid);
                    Console.WriteLine("It's a draw!");
                    break;
                }
            }

            Console.WriteLine("Game Over. Thanks for playing!");
        }
    }

}


