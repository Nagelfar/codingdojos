using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLifeImpl
{
    public class Cell
    {


        public Cell North
        {
            get;
            set;
        }

        public Cell South { get; set; }
        public Cell East { get; set; }
        public Cell West { get; set; }
        public Cell NorthEast { get; set; }
        public Cell SouthEast { get; set; }
        public Cell SouthWest { get; set; }
        public Cell NorthWest { get; set; }

        public int AliveCells
        {
            
            get
            {
                var list = new List<Cell>();
                
                list.Add(North);
                list.Add(NorthEast);
                list.Add(East);
                list.Add(SouthEast);
                list.Add(South);
                list.Add(SouthWest);
                list.Add(West);
                list.Add(NorthWest);

                return list.Count(x => x != null);
            }
        }

    }
}
