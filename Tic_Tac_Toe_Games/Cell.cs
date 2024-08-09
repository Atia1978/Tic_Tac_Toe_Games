using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tic_Tac_Toe_Games
{
    public class Cell
    {
        public int Rows { get; }
        public int Columns { get; }
        public Cell(int row ,int colunms) 
        {
            Rows = row; 
            Columns = colunms;
        }

    }
}
