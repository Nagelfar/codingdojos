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
            return new Position(new BoardSize(10,10),x, y);
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

            Assert.AreEqual( Position(2, 2), position1.Add( position2.X,position1.Y));
        }
      
        [TestMethod]
        public void WhenUsingABoardSizeBiggerThanThePositions_ThenTheCorrdinatesAreNotWrapped()
        {
            var boardSize = new BoardSize(10, 10);
 
            var position = new Position(boardSize,5,5);

            Assert.AreEqual(new Position(boardSize, 5, 5),position);
        }
    }
}
