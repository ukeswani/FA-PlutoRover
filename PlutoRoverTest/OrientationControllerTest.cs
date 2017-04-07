using Microsoft.VisualStudio.TestTools.UnitTesting;
using PlutoRover;
using System;
using System.Collections.Generic;

namespace PlutoRoverTest
{
    [TestClass]
    public class OrientationControllerTest
    {
        private IOrientationController SetUp()
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

            IOrientationController orientationController = new OrientationController(north, orientations);

            return orientationController;
        }

        [TestMethod]
        public void TurnLeftFromOrigin()
        {
            var orientationController = SetUp();

            orientationController.TurnLeft();

            string newOrientation = orientationController.GetCurrentOrientation();

            Assert.AreEqual("W", newOrientation, "Turning left from North does not give West");
        }

        [TestMethod]
        public void TurnRightFromOrigin()
        {

            var orientationController = SetUp();

            orientationController.TurnRight();

            string newOrientation = orientationController.GetCurrentOrientation();

            Assert.AreEqual("E", newOrientation, "Turning Right from North does not give East");
        }
    }

   

    public class DummyOrientation : IOrientation
    {
        public IOrientation Left
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public string Name
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public IOrientation Right
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }
    }

    public interface IOrientationController
    {
        void TurnLeft();

        void TurnRight();

        string GetCurrentOrientation();
    }

    public class OrientationController : IOrientationController
    {
        private IOrientation _currentOrientation;
        private IDictionary<string, IOrientation> _orientations;

        public OrientationController
                (
                     IOrientation startingOrientation
                    ,IDictionary<string, IOrientation> orientations
                )
        {
            _currentOrientation = startingOrientation;
            _orientations = orientations;

        }

        public string GetCurrentOrientation()
        {
            return _currentOrientation.Name;
        }

        public void TurnLeft()
        {
            _currentOrientation = _orientations[_currentOrientation.Name].Left;
        }

        public void TurnRight()
        {
            _currentOrientation = _orientations[_currentOrientation.Name].Right;
        }
    }


}
