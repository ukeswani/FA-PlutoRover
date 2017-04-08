using Microsoft.VisualStudio.TestTools.UnitTesting;
using PlutoRover;
using PlutoRover.Interfaces;
using System.Collections.Generic;

namespace PlutoRoverTest
{
    [TestClass]
    public class OrientationManagerTest
    {
        private IOrientationManager SetUp()
        {
            var orientations = new Dictionary<string, IOrientation>();


            var north = new PlutoRover.Orientation("N");
            var east = new PlutoRover.Orientation("E");
            var west = new PlutoRover.Orientation("W");
            var south = new PlutoRover.Orientation("S");

            north.Left = west;
            north.Right = east;

            east.Left = north;
            east.Right = south;

            south.Left = east;
            south.Right = west;

            west.Left = south;
            west.Right = north;

            orientations.Add(north.Name, north);
            orientations.Add(east.Name, east);
            orientations.Add(west.Name, west);
            orientations.Add(south.Name, south);

            IOrientationManager orientationManager = new OrientationManager(north, orientations);

            return orientationManager;
        }

        [TestMethod]
        public void TurnLeftFromOrigin()
        {
            var orientationManager = SetUp();

            orientationManager.TurnLeft();

            string newOrientation = orientationManager.GetCurrentOrientation();

            Assert.AreEqual("W", newOrientation, "Turning left from North does not give West");
        }

        [TestMethod]
        public void TurnRightFromOrigin()
        {

            var orientationManager = SetUp();

            orientationManager.TurnRight();

            string newOrientation = orientationManager.GetCurrentOrientation();

            Assert.AreEqual("E", newOrientation, "Turning Right from North does not give East");
        }
    }
}
