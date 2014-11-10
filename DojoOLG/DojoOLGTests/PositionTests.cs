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

        [TestMethod]
        public void WhenConstructingThePosition_TwoDifferentInstancesAreTheSame()
        {
            var rover = new Position(0, 0);

            Assert.AreEqual(new Position(0, 0), rover);
        }
        [TestMethod]
        public void WhenAddingTwoPositions_TheResultIsCorrect()
        {
            var position1 = new Position(1, 1);
            var position2 = new Position(1, 1);

            Assert.AreEqual(new Position(2, 2), position1 + position2);
        }
        [TestMethod]
        public void WhenInvertingAPosition_TheResultIsCorrect()
        {
            var position = new Position(1, 1);

            Assert.AreEqual(new Position(-1, -1), -position);
        }
    }
}
