using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GameOfLifeImpl;
using System.Collections.Generic;
using System.Linq;
namespace GameOfLifeTimer
{
    [TestClass]
    public class CellTests
    {
        private Cell NewCell()
        {
            return new Cell(0, 0);
        }
        [TestMethod]
        public void TestMethod1()
        {
            var c = new Class1();
            Assert.IsNotNull(c);
        }

        [TestMethod]
        public void CanCreateNewCell()
        {
            var cell = NewCell();

            Assert.IsNotNull(cell);
        }

        [TestMethod]
        public void SameCellsAreUnique()
        {
            var cell1 = NewCell();
            var cell2 = NewCell();
            var set = new HashSet<Cell>();

            set.Add(cell1);
            set.Add(cell2);

            Assert.AreEqual(set.Count, 1);
        }

        //[TestMethod]
        //public void Returns8Neigh()
        //{
        //    var cell = new Cell(0,0);
        //    Assert.AreEqual(8, cell.Neighbour.Count());
        //}

        [TestMethod]
        public void NeighboursContainsUpperLeft()
        {
            var cell = new Cell(0, 0);
            CollectionAssert.Contains(cell.Neighbour.ToList(), new Cell(-1, -1));
        }
        [TestMethod]
        public void NeighboursContainsUpper()
        {
            var cell = new Cell(0, 0);
            CollectionAssert.Contains(cell.Neighbour.ToList(), new Cell(0, -1));
        }
        [TestMethod]
        public void NeighboursContainsUpperRight()
        {
            var cell = new Cell(0, 0);
            CollectionAssert.Contains(cell.Neighbour.ToList(), new Cell(1, -1));
        }
        [TestMethod]
        public void NeighboursContainsLeft()
        {
            var cell = new Cell(0, 0);
            CollectionAssert.Contains(cell.Neighbour.ToList(), new Cell(-1, 0));
        }
        [TestMethod]
        public void NeighboursContainsRight()
        {
            var cell = new Cell(0, 0);
            CollectionAssert.Contains(cell.Neighbour.ToList(), new Cell(1, 0));
        }

        [TestMethod]
        public void NeighboursContainsLowerLeft()
        {
            var cell = new Cell(0, 0);
            CollectionAssert.Contains(cell.Neighbour.ToList(), new Cell(-1, 1));
        }

        [TestMethod]
        public void NeighboursContainsLowerMioddle()
        {
            var cell = new Cell(0, 0);
            CollectionAssert.Contains(cell.Neighbour.ToList(), new Cell(0, 1));
        }
    }
}
