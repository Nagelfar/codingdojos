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
            var space = new Space();

            Assert.IsTrue(space.IsEmpty);
        }
    }
}
