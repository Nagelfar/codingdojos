﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GameOfLifeImpl;

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


    }
}
