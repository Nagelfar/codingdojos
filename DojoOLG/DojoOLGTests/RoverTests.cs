using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DojoOLGFsharp;
namespace DojoOLGTests
{
    [TestClass]
    public class RoverTests
    {
        private Position Position(int x, int y)
        {
            return new Position(new BoardSize(10,10),x, y);
        }

        [TestMethod]
        public void WhenMovingForward_YMustBeIncreaded()
        {
            var position =  Position(0, 0);
            var heading = new Heading('N');

            var rover = new Rover(position, heading);

            var newRover = rover.Execute('f');

            Assert.AreEqual(new Rover( Position(0, 1), heading), newRover);
        }
        [TestMethod]
        public void WhenMovingBackwards_YMustBeDecreased()
        {
            var position =  Position(0, 0);
            var heading = new Heading('N');

            var rover = new Rover(position, heading);

            var newRover = rover.Execute('b');

            Assert.AreEqual(new Rover( Position(0, -1),heading) ,newRover);
        }

        [TestMethod]
        public void WhenMovingBackwards_YMustBeDecreased2()
        {
            var position =  Position(1, 0);
            var heading = new Heading('N');

            var rover = new Rover(position, heading);

            var newRover = rover.Execute('b');

            Assert.AreEqual(new Rover( Position(1, -1), heading), newRover);
        }

        [TestMethod]
        public void WhenTurningLeft_TheHeadingMustChange_ToWest()
        {
            var position =  Position(0, 0);
            var heading = new Heading('N');

            var rover = new Rover(position, heading);

            var newRover = rover.Execute('l');

            Assert.AreEqual(new Rover( Position(0, 0), new Heading('W')), newRover);
        }

        [TestMethod]
        public void WhenTurninRight_TheHeadingMustChange_ToEast()
        {
            var position =  Position(0, 0);
            var heading = new Heading('N');

            var rover = new Rover(position, heading);

            var newRover = rover.Execute('r');

            Assert.AreEqual(new Rover( Position(0, 0), new Heading('E')), newRover);
        }

        [TestMethod]
        public void WhenCalledWithString_ThenEachCharIsInterpretedAsCommand()
        {
            var command = "ff";
            var position = Position(0, 0);
            var heading = new Heading('N');

            var rover = new Rover(position, heading);

            var newRover = rover.Execute(command);

            Assert.AreEqual(new Rover(Position(0,2), new Heading('E')), newRover);
        }
       
    }
}
