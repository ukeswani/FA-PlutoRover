using Microsoft.VisualStudio.TestTools.UnitTesting;
using PlutoRover;
using PlutoRover.Interfaces;
using PlutoRoverTest.Dummies;

namespace PlutoRoverTest
{
    [TestClass]
    public class LocationManagerTest
    {
        [TestMethod]
        public void MoveForwardFromNorth()
        {
            IOrientationReader orientationReader = new DummyOrientationReader("N");
            ILocationManager locationManager = new LocationManager
                                                    (
                                                         0
                                                        ,0
                                                        ,100
                                                        ,100
                                                        ,orientationReader
                                                    );

            locationManager.MoveForward();

            var currentLocation = locationManager.GetCurrentLocation();

            Assert.AreEqual("0,1", currentLocation, "Moving forward from 0,0 facing North does not give 0,1");

        }

        [TestMethod]
        public void MoveBackwardFromNorth()
        {
            IOrientationReader orientationReader = new DummyOrientationReader("N");
            ILocationManager locationManager = new LocationManager
                                                    (
                                                         0
                                                        ,0
                                                        ,100
                                                        ,100
                                                        ,orientationReader
                                                    );

            locationManager.MoveBackward();

            var currentLocation = locationManager.GetCurrentLocation();

            Assert.AreEqual("0,-1", currentLocation, "Moving forward from 0,0 facing North does not give 0,-1");

        }

        [TestMethod]
        public void MoveForwardFromEast()
        {
            IOrientationReader orientationReader = new DummyOrientationReader("E");
            ILocationManager locationManager = new LocationManager
                                                    (
                                                         1
                                                        ,1
                                                        ,100
                                                        ,100
                                                        ,orientationReader
                                                    );

            locationManager.MoveForward();

            var currentLocation = locationManager.GetCurrentLocation();

            Assert.AreEqual("2,1", currentLocation, "Moving forward from 1,1 facing East does not give 2,1");

        }

        [TestMethod]
        public void MoveBackwardFromEast()
        {
            IOrientationReader orientationReader = new DummyOrientationReader("E");
            ILocationManager locationManager = new LocationManager
                                                    (
                                                         1
                                                        ,1
                                                        ,100
                                                        ,100
                                                        ,orientationReader
                                                    );

            locationManager.MoveBackward();

            var currentLocation = locationManager.GetCurrentLocation();

            Assert.AreEqual("0,1", currentLocation, "Moving backward from 1,1 facing East does not give 0,1");

        }

        [TestMethod]
        public void MoveForwardFromSouth()
        {
            IOrientationReader orientationReader = new DummyOrientationReader("S");
            ILocationManager locationManager = new LocationManager
                                                    (
                                                         2
                                                        ,2
                                                        ,100
                                                        ,100
                                                        ,orientationReader
                                                    );

            locationManager.MoveForward();

            var currentLocation = locationManager.GetCurrentLocation();

            Assert.AreEqual("2,1", currentLocation, "Moving forward from 2,2 facing South does not give 2,1");

        }

        [TestMethod]
        public void MoveBackwardFromSouth()
        {
            IOrientationReader orientationReader = new DummyOrientationReader("S");
            ILocationManager locationManager = new LocationManager
                                                    (
                                                         2
                                                        ,2
                                                        ,100
                                                        ,100
                                                        ,orientationReader
                                                    );

            locationManager.MoveBackward();

            var currentLocation = locationManager.GetCurrentLocation();

            Assert.AreEqual("2,3", currentLocation, "Moving backward from 2,2 facing South does not give 2,3");

        }

        [TestMethod]
        public void MoveForwardFromWest()
        {
            IOrientationReader orientationReader = new DummyOrientationReader("W");
            ILocationManager locationManager = new LocationManager
                                                    (
                                                         3
                                                        ,3
                                                        ,100
                                                        ,100
                                                        ,orientationReader
                                                    );

            locationManager.MoveForward();

            var currentLocation = locationManager.GetCurrentLocation();

            Assert.AreEqual("2,3", currentLocation, "Moving forward from 3,3 facing West does not give 2,3");

        }

        [TestMethod]
        public void MoveBackwardFromWest()
        {
            IOrientationReader orientationReader = new DummyOrientationReader("W");
            ILocationManager locationManager = new LocationManager
                                                    (
                                                         3
                                                        ,3
                                                        ,100
                                                        ,100
                                                        ,orientationReader
                                                    );

            locationManager.MoveBackward();

            var currentLocation = locationManager.GetCurrentLocation();

            Assert.AreEqual("4,3", currentLocation, "Moving backward from 3,3 facing West does not give 4,3");

        }

        [TestMethod]
        public void MoveBackwardFromWest_WrapAround()
        {
            IOrientationReader orientationReader = new DummyOrientationReader("W");
            ILocationManager locationManager = new LocationManager
                                                    (
                                                         100
                                                        ,100
                                                        ,100
                                                        ,100
                                                        ,orientationReader
                                                    );

            locationManager.MoveBackward();

            var currentLocation = locationManager.GetCurrentLocation();

            Assert.AreEqual("0,100", currentLocation, "Moving backward from 100,100 facing West does not give 0,100");
        }

        [TestMethod]
        public void MoveForwardFromEast_WrapAround()
        {
            IOrientationReader orientationReader = new DummyOrientationReader("E");
            ILocationManager locationManager = new LocationManager
                                                    (
                                                         100
                                                        ,100
                                                        ,100
                                                        ,100
                                                        ,orientationReader
                                                    );

            locationManager.MoveForward();

            var currentLocation = locationManager.GetCurrentLocation();

            Assert.AreEqual("0,100", currentLocation, "Moving Forward from 100,100 facing East does not give 0,100");
        }
    }        
}
