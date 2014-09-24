using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLifeImpl
{
    public struct Cell
    {
        private int x;
        private int y;

        public Cell(int x, int y)
        {
            // TODO: Complete member initialization
            this.x = x;
            this.y = y;
        }

        public IEnumerable<Cell> Neighbour
        {
            get
            {
                return new Cell[]{
                    new Cell(x-1,y-1)
                };
            }
        }
    }
}
