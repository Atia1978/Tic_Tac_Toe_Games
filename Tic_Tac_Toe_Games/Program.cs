using Tic_Tac_Toe_Games;

namespace Tic_Tac_teo_GPT
{
    internal class Program
    {
        private static char userSymbol;
        public static char[,] grid = new char[GameElement.GRID_SIZE,GameElement.GRID_SIZE];
        static void Main(string[] args)
        {
            GameCodes.ResetGrid(grid);
            userSymbol = UIGame.ChooseSymbol();
            GameCodes.ChosePlayerSymbols(userSymbol);

            while (true)
            {
                UIGame.DisplayGrid(grid);
                GameCodes.PlayerMove(grid);

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
                GameCodes.AIMove(grid);

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
    

