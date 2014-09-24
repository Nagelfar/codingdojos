using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLifeImpl
{
    public class Space
    {
        private Cell[] cell;

        public Space(Cell[] cell)
        {
            // TODO: Complete member initialization
            this.cell = cell;
        }
        public bool IsEmpty { get { return !cell.Any(); } }
    }
}
