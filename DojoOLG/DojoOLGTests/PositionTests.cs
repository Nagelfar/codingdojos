using DojoOLGFsharp;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DojoOLGTests
{
    [TestClass]
    public class PositionTests
    {
        private Position Position(int x, int y)
        {
            return new Position(x, y);
        }

        [TestMethod]
        public void WhenConstructingThePosition_TwoDifferentInstancesAreTheSame()
        {
            var rover =  Position(0, 0);

            Assert.AreEqual( Position(0, 0), rover);
        }
        [TestMethod]
        public void WhenAddingTwoPositions_TheResultIsCorrect()
        {
            var position1 =  Position(1, 1);
            var position2 =  Position(1, 1);

            Assert.AreEqual( Position(2, 2), position1 + position2);
        }
        [TestMethod]
        public void WhenInvertingAPosition_TheResultIsCorrect()
        {
            var position =  Position(1, 1);

            Assert.AreEqual( Position(-1, -1), -position);
        }
    }
}
