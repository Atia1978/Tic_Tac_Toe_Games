using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tic_Tac_Toe_Games
{
    public class Cell
    {
        public int Row { get; }
        public int Col { get; }
        public Cell(int row ,int col) 
        {
            Row = row; 
            Col = col;
        }

    }
}
