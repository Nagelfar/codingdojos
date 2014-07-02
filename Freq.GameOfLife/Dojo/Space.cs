using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dojo
{
    public class Space
    {
        private IList<Cell> _cells = new List<Cell>();
        public Cell Cell(int x, int y)
        {
            var found = _cells.SingleOrDefault(c => c.X == x && c.Y == y);
            if (found == null)
            {
                found = new Cell(false, x, y);
                _cells.Add(found);
            }
            return found;
        }

        public void setCellAlive(int x, int y)
        {
            Cell(x, y).State = true;
        }

        public int AliveNeighbours(int x, int y)
        {
            return GetNeighbours(x, y).Count(c => c.State == true);
        }

        private IEnumerable<Cell> GetNeighbours(int x, int y)
        {
            return DistanceToNeighbour().Select(c => Cell(x + c.Item1, y + c.Item2));
        }

        private IEnumerable<Tuple<int, int>> DistanceToNeighbour()
        {
            yield return Tuple.Create(-1, -1);
            yield return Tuple.Create(-1, 0);
            yield return Tuple.Create(-1, 1);
            yield return Tuple.Create(0, -1);
            yield return Tuple.Create(0, 1);
            yield return Tuple.Create(1, -1);
            yield return Tuple.Create(1, 0);
            yield return Tuple.Create(1, 1);

        }

        public bool HasUnderPopulation(int x, int y)
        {
            return AliveNeighbours(x, y) < 2;
        }

        public bool CanLive(int x, int y)
        {
            return !HasOverPopulation(x, y) && !HasUnderPopulation(x, y);
        }

        public bool HasOverPopulation(int x, int y)
        {
            return AliveNeighbours(x, y) > 3;
        }

        public bool IsCellReborn(int x, int y)
        {
            return !Cell(x,y).State  && AliveNeighbours(x, y) == 3;
        }

        public Space Tick()
        {
            var s = new Space ();

            foreach (var cell in _cells.ToList())
            {
                if (CanLive(cell.X, cell.Y) || IsCellReborn(cell.X, cell.Y))
                    s.setCellAlive(cell.X, cell.Y);

                foreach (var neighbour in GetNeighbours(cell.X, cell.Y))
                    if (IsCellReborn(neighbour.X, neighbour.Y))
                        s.setCellAlive(neighbour.X, neighbour.Y);
            }

            return s;
        }

        public IEnumerable<Cell> AliveCells
        {
            get { return _cells; }
        }
    }
}
