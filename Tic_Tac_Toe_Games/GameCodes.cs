using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Numerics;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;


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


        public static void ResetGrid()
        {
            for (int column = 0; column < GRID_SIZE; column++)
            {
                for (int rows = 0; rows < GRID_SIZE; rows++)
                {
                    grid[column, rows] = ' ';
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
            for (int column =0; column < GRID_SIZE-1; column++)
            {
                for (int rows = 0; rows < GRID_SIZE; rows++)
                {
                    Console.Write(grid[column, rows]);
                    if (rows < GRID_SIZE -1 ) Console.Write("   | ");
                }
                Console.WriteLine();
                if (column < GRID_SIZE -1 ) Console.WriteLine( " ----------- " );
            }
        }
        public static Players CheckWinner()
        {
            int winner;
            for (winner = 1;winner < GRID_SIZE;winner++)
            {
                if (IsColumnWinning(winner))
                {
                    return (grid[winner, 0] == userSymbol) ? Players.User : Players.AI;
                }
                if (IsRowsWinning(winner))
                {
                    return (grid[0,winner] == userSymbol) ? Players.User :Players.AI;
                }
                
            }

        }

        public static bool IsRowsWinning(int rows)
        {
         
            int column;
            firstSymbol = grid[rows, 0];
            if (firstSymbol == EMPTY_SYMBOL)
            {
                return false;
            }
            for (column = 1; column < GRID_SIZE; column++)
            {
                if (firstSymbol != grid[rows, column])
                {
                    return false;
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
            firstSymbol = grid[0,0];
            if (firstSymbol != EMPTY_SYMBOL)
                {

            }
        }
    }

        }
       


    }
}

