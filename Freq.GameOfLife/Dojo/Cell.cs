using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dojo
{
    public class Cell
    {
        
        public Cell(bool state, int x, int y) {
            State = state;
            X = x;
            Y = y;
        }
        public bool State
        {
            get;
            set;
        }

        public int Y { get; private set; }

        public int X { get; private set; }
    }
}
