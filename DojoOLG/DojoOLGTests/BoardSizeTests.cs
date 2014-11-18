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
    public class BoardSizeTests
    {
   
        [TestMethod]
        public void WhenMovedOutsideOfPositiveXBorder_PositionIsWrapped()
        {
            var boardSize = new BoardSize(10, 10);
            
            var newPosition = boardSize.WrapX(1);

            Assert.AreEqual(1, newPosition);
        }
        [TestMethod]
        public void WhenWrappingAValidXPosition_ItShouldNotBeChanged()
        {
            var boardSize = new BoardSize(10, 10);
            var newX = boardSize.WrapX(5);

            Assert.AreEqual(newX, 5);
        }
        [TestMethod]
        public void WhenWrappingAValidYPosition_ItShouldNotBeChanged()
        {
            var boardSize = new BoardSize(10, 10);
            var newY = boardSize.WrapY(5);

            Assert.AreEqual(newY, 5);
        }
        [TestMethod]
        public void WhenCreatingAValidPosition_IsShouldBeCreatedUnWrapped()
        {
            var boardSize = new BoardSize(10, 10);

            var newPosition = Board.BoardPosition(boardSize,5, 5);

            Assert.AreEqual(new Position(boardSize,5, 5), newPosition);
        }
        [TestMethod]
        public void WhenCreatingAPosition_IsShouldBeWrapped()
        {
            var boardSize = new BoardSize(10, 10);

            var newPosition = Board.BoardPosition(boardSize,11, 11);

            Assert.AreEqual(new Position(boardSize,1, 1), newPosition);
        }
    }
}
