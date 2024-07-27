﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tic_Tac_Toe_Games
{
    public  class UITicTacTeoMethode
    {
        public static void StartGame()
        {
            GameCodes.ResetGrid();
            char userSymbol;
            while (true)
            {
                Console.WriteLine("Choose your symbol (X or O): ");
                userSymbol = char.ToUpper(Console.ReadLine()[0]);
                if (userSymbol == 'X' || userSymbol == 'O')
                {
                    break;

                }
                Console.WriteLine("Invalid symbol. Please choose X or O.");
            }

            GameCodes.ChosePlayerSymbols(userSymbol);

            while (true)
            {
                Console.Clear();
                GameCodes.DisplayGrid();

                if (GameCodes.CheckWinner() != Players.None)
                {
                    Console.WriteLine($"Player {GameCodes.CheckWinner()} wins!");
                    break;
                }

                if (GameCodes.IsGridFull())
                {
                    Console.WriteLine("It's a draw!");
                    break;
                }

                GameCodes.PlayerMove();

                if (GameCodes.CheckWinner() != Players.None)
                {
                    Console.Clear();
                    GameCodes.DisplayGrid();
                    Console.WriteLine($"Player {GameCodes.CheckWinner()} wins!");
                    break;
                }
                if (GameCodes.IsGridFull())
                {
                    Console.Clear();
                    GameCodes.DisplayGrid();
                    Console.WriteLine("It's a draw!");
                    break;
                }
                GameCodes.ATMove();
            }

        }
    }
    }
