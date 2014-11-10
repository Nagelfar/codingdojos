using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DojoOLGFsharp;
namespace DojoOLGTests
{
    [TestClass]
    public class RoverTests
    {
      
        [TestMethod]
        public void WhenMovingForward_YMustBeIncreaded()
        {
            var position = new Position(0, 0);
            var heading = new Heading('N');

            var rover = new Rover(position, heading);

            var newRover = rover.Execute('f');

            Assert.AreEqual(new Rover(new Position(0, 1), heading), newRover);
        }
        [TestMethod]
        public void WhenMovingBackwards_YMustBeDecreased()
        {
            var position = new Position(0, 0);
            var heading = new Heading('N');

            var rover = new Rover(position, heading);

            var newRover = rover.Execute('b');

            Assert.AreEqual(new Rover(new Position(0, -1),heading) ,newRover);
        }

        [TestMethod]
        public void WhenTurningLeft_TheHeadingMustChange_ToWest()
        {
            var position = new Position(0, 0);
            var heading = new Heading('N');

            var rover = new Rover(position, heading);

            var newRover = rover.Execute('l');

            Assert.AreEqual(new Rover(new Position(0, 0), new Heading('W')), newRover);
        }

        [TestMethod]
        public void WhenTurninRight_TheHeadingMustChange_ToEast()
        {
            var position = new Position(0, 0);
            var heading = new Heading('N');

            var rover = new Rover(position, heading);

            var newRover = rover.Execute('r');

            Assert.AreEqual(new Rover(new Position(0, 0), new Heading('E')), newRover);
        }
       
    }
}
