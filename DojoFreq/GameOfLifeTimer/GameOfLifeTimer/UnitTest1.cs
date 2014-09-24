using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GameOfLifeImpl;
using System.Collections.Generic;
using System.Linq;
namespace GameOfLifeTimer
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var c = new Class1();
            Assert.IsNotNull(c);
        }

        [TestMethod]
        public void CanCreateNewCell()
        {
            var cell = new Cell(1, 1);

            Assert.IsNotNull(cell);
        }

        [TestMethod]
        public void SameCellsAreUnique()
        {
            var cell1 = new Cell(1, 1);
            var cell2 = new Cell(1, 1);
            var set = new HashSet<Cell>();

            set.Add(cell1);
            set.Add(cell2);

            Assert.AreEqual(set.Count, 1);              
        }

        [TestMethod]
        public void Returns8Neigh()
        {
            var cell = new Cell(0,0);
            Assert.AreEqual(8, cell.Neighbour.Count());
        }

    }
}
