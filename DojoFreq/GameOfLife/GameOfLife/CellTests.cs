using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GameOfLifeImpl;

namespace GameOfLife
{
    [TestClass]
    public class CellTests
    {

        [TestMethod]
        public void CanRetrieveNorthNeeighour()
        {
            var tmp = new Cell();
            var sut = new Cell();

            sut.North = tmp;

            Assert.AreEqual(sut.North, tmp);
        }

        [TestMethod]
        public void CanRetrieveSouthNeeighour()
        {
            var tmp = new Cell();
            var sut = new Cell();

            sut.South = tmp;

            Assert.AreEqual(sut.South, tmp);
        }

        [TestMethod]
        public void Given_no_neighbours_the_count_should_be_zero()
        {

            var sut = new Cell();

            Assert.AreEqual(sut.AliveCells, 0);
        }

        [TestMethod]
        public void Given_one_neighbours_the_count_should_be_one()
        {

            var sut = new Cell();
            var neighbour = new Cell();

            sut.NorthEast = neighbour;

            Assert.AreEqual(sut.AliveCells, 1);
        }


        [TestMethod]
        public void Given_two_neighbours_the_count_should_be_two()
        {
            var sut = new Cell()
            {
                NorthEast = new Cell(),
                South = new Cell()
            };
            Assert.AreEqual(2, sut.AliveCells);
        }

        [TestMethod]
        public void A_Dead_Cell_Is_dead()
        {
            var sut = new Cell();
            Assert.AreEqual(false, sut.isAlive());
        }

    }
}
