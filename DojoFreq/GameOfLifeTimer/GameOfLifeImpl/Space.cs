using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLifeImpl
{
    public class Space
    {
        private IEnumerable<Cell> _cells;

        public Space(IEnumerable<Cell> cells)
        {
            this._cells = cells;
        }
        public bool IsEmpty { get { return !_cells.Any(); } }
    }
}
