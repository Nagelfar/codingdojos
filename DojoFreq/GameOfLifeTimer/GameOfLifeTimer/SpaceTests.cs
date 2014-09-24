using GameOfLifeImpl;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLifeTimer
{
    [TestClass]
    public class SpaceTests
    {
        [TestMethod]
        public void EmptySpaceIsEmpty()
        {
            var space = new Space(new Cell[0]);

            Assert.IsTrue(space.IsEmpty);
        }
      [TestMethod]
        public void OneCell_SpaceIsNotEmpty()
        {
            var space = new Space(new[] { new Cell(0, 0) });

            Assert.IsFalse(space.IsEmpty);
        }
    }
}
