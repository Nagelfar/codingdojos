using System;

using NUnit.Framework;

namespace Dojo.Tests
{
    [TestFixture]
    public class UnitTest1
    {
        private Space space;
        [SetUp]
        public void setUp()
        {
            space = new Space();
        }


        [Test]
        public void CanGetGetStateOfCell()
        {
            Assert.That(space.Cell(0, 0).State, Is.False);
        }

        [Test]
        public void CanSetStateOfCellToAlive()
        {
            space.setCellAlive(9, 9);
            Assert.That(space.Cell(9, 9).State, Is.True);
        }

        [Test]
        public void CountTwoAliveNeighboursOfCell()
        {
            space.setCellAlive(0, 0);
            space.setCellAlive(0, 1);

            Assert.That(space.AliveNeighbours(1, 0), Is.EqualTo(2));
        }

        [Test]
        public void CountThreeAliveNeighboursOfCell()
        {
            space.setCellAlive(0, 0);
            space.setCellAlive(0, 1);
            space.setCellAlive(1, 1);

            Assert.That(space.AliveNeighbours(1, 0), Is.EqualTo(3));
        }


        [Test]
        public void HasUnderPopulation_should_be_true_if_no_neighbours()
        {
            Assert.That(space.HasUnderPopulation(0, 0), Is.True);
        }

        [Test]
        public void HasNoUnderPopulation_when_cell_has_two_alive_neighours()
        {
            space.setCellAlive(0, 0);
            space.setCellAlive(0, 1);
            Assert.That(space.HasUnderPopulation(1, 0), Is.False);
        }
        [Test]
        public void CannotLiveOn_when_cell_has_one_alive_neighbours()
        {
            space.setCellAlive(0, 0);

            Assert.That(space.CanLive(1, 0), Is.False);
        }
        [Test]
        public void CanLifeOn_when_cell_has_two_alive_neighours()
        {
            space.setCellAlive(0, 0);
            space.setCellAlive(0, 1);

            Assert.That(space.CanLive(1, 0), Is.True);
        }
        [Test]
        public void CannotLiveOn_when_cell_has_more_than_three_neigbours()
        {
            space.setCellAlive(0, 0);
            space.setCellAlive(0, 1);
            space.setCellAlive(0, -1);
            space.setCellAlive(2, 0);

            Assert.That(space.CanLive(1, 0), Is.False);
        }

        [Test]
        public void HasOverPopulation_should_be_false_if_no_neighbours()
        {
            Assert.That(space.HasOverPopulation(0, 0), Is.False);
        }

        [Test]
        public void HasOverPopulation_should_be_true_if_more_than_three_neighbours()
        {
            space.setCellAlive(0, 0);
            space.setCellAlive(0, 1);
            space.setCellAlive(0, -1);
            space.setCellAlive(2, 0);

            Assert.That(space.HasOverPopulation(1, 0), Is.True);
        }

        [Test]
        public void IsCellReborn_should_be_true_if_three_neighbors()
        {
            space.setCellAlive(0, 0);
            space.setCellAlive(0, 1);
            space.setCellAlive(0, -1);

            Assert.That(space.IsCellReborn(1, 0), Is.True);
        }
        [Test]
        public void IsCellReborn_should_be_false_if_less_than_three_neighbours()
        {
            Assert.That(space.IsCellReborn(0, 0), Is.False);
        }
        [Test]
        public void IsCellReborn_should_be_false_if_cell_is_alive()
        {
            space.setCellAlive(0, 0);
            space.setCellAlive(0, 1);
            space.setCellAlive(0, -1);
            space.setCellAlive(1, 0);

            Assert.That(space.IsCellReborn(1, 0), Is.False);
        }

        [Test]
        public void AliveCellsShould_be_empty_on_empty_space()
        {
            Assert.That(space.AliveCells, Is.Empty);
        }
        
        [Test]
        public void Tick_should_create_a_new_space()
        {
            Assert.That(space.Tick(), Is.Not.SameAs(space));
        }

        [Test]
        public void A_space_with_two_alive_neighbours_has_three_alive_cells_after_tick()
        {
            space.setCellAlive(0, 0);
            space.setCellAlive(0, 1);
            space.setCellAlive(0, 2);

            var sut = space.Tick();
            Assert.That(sut.AliveCells, Has.Count.EqualTo(3));
        }
        [Test]
        public void A_space_with_a_single_active_cell_should_be_empty_after_the_tick()
        {
            space.setCellAlive(0, 0);

            var sut = space.Tick();
            Assert.That(sut.AliveCells, Is.Empty);
        }

        [Test]
        public void A_space_with_three_neighbouring_cells_and_a_dead_should_create_a_new_cell()
        {
            space.setCellAlive(0, 0);
            space.setCellAlive(0, 1);
            space.setCellAlive(1, 1);

            var sut = space.Tick();
            Assert.That(sut.AliveCells, Has.Count.EqualTo(4));
        }

        [Test]
        public void A_space_with_a_2x2_block_should_remain_constant()
        {
            space.setCellAlive(0, 0);
            space.setCellAlive(0, 1);
            space.setCellAlive(1, 1);
            space.setCellAlive(1, 0);

            var sut = space.Tick();

            Assert.That(sut.AliveCells, Has.Count.EqualTo(4));
        }
    }
}
