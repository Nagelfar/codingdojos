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
    public class HeadingTests
    {
        [TestMethod]
        public void WhenConstructingAHeading_TwoDifferentInstancesAreEqual()
        {
            var heading = new Heading('N');

            Assert.AreEqual(new Heading('N'), heading);
        }

        [TestMethod]
        public void WhenMovingNorth_YIsIncreased()
        {
            var rover = new Position(0, 0).North();

            Assert.AreEqual(new Position(0, 1), rover);
        }
        [TestMethod]
        public void WhenMovingSouth_YIsDecreased()
        {
            var rover = new Position(0, 0).South();

            Assert.AreEqual(new Position(0, -1), rover);
        }
        [TestMethod]
        public void WhenMovingEast_XIsIncreased()
        {
            var rover = new Position(0, 0).East();

            Assert.AreEqual(new Position(1, 0), rover);
        }
        [TestMethod]
        public void WhenMovingWest_XIsDecreased()
        {
            var rover = new Position(0, 0).West();

            Assert.AreEqual(new Position(-1, 0), rover);
        }


        [TestMethod]
        public void WhenConstructionARover_TwoRovesMustBeEqual()
        {
            var position = new Position(0, 0);
            var heading = new Heading('f');
            var rover = new Rover(position, heading);

            
            Assert.AreEqual(rover, new Rover(new Position(0,0),new Heading('f')));
        }

        [TestMethod]
        public void WhenHeadingNorth_AndMoving_XMustBeIncreasedByOne()
        {
            var position = new Position(0, 0);
            var heading = new Heading('N');

            var newPosition = heading.Move(position);

            Assert.AreEqual(new Position(0, 1), newPosition);
        }
        [TestMethod]
        public void WhenRotatingLeft_HeadingChangedToWest()
        {
            var heading = new Heading('N');

            var newHeading = heading.RotateLeft();

            Assert.AreEqual(new Heading('W'), newHeading);
        }
    }
}
