﻿using DojoOLGFsharp;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DojoOLGTests
{
    [TestClass]
    public class BoardTests
    {
        [TestMethod]
        public void WhenWrappingAValidPosition_ItShouldNotBeChanged()
        {
            var boardSize = new BoardSize(10, 10);
            var position = new Position(5, 5);
            var newPosition = boardSize.Wrap(position);

            Assert.AreEqual(new Position(5, 5), newPosition);
        }
        [TestMethod]
        public void WhenMovedOutsideOfPositiveXBorder_PositionIsWrapped()
        {
            var boardSize = new BoardSize(10, 10);
            var position = new Position(11, 9);
            var newPosition = boardSize.Wrap(position);

            Assert.AreEqual(new Position(1, 9), newPosition);
        }
    }
}