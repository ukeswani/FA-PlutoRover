using Microsoft.VisualStudio.TestTools.UnitTesting;
using PlutoRover.Interfaces;
using PlutoRoverTest.Dummies;
using System.Collections.Generic;

namespace PlutoRoverTest
{
    [TestClass]
    public class AlternativeLocationManagerTest
    {
        [TestMethod]
        public void MoveForwardFromNorth()
        {
            IOrientationReader orientationReader = new DummyOrientationReader("N");
            var startingCoOrdinates = new CoOrdinates(0, 0);

            var strategies = new Dictionary<string, ILocationChangeStrategy>();
            strategies.Add("N", new FacingNorth());
            strategies.Add("E", new FacingEast());
            strategies.Add("W", new FacingWest());
            strategies.Add("S", new FacingSouth());

            ILocationManager locationManager = new AlternativeLocationManager
                                                    (
                                                         startingCoOrdinates
                                                        ,100
                                                        ,100
                                                        ,orientationReader
                                                        ,strategies
                                                    );

            locationManager.MoveForward();

            var currentLocation = locationManager.GetCurrentLocation();

            Assert.AreEqual("0,1", currentLocation, "Moving forward from 0,0 facing North does not give 0,1");
        }
    }

    public class CoOrdinates
    {
        private int _x;
        private int _y;

        public CoOrdinates
                (
                     int x
                    , int y
                )
        {
            _x = x;
            _y = y;
        }

        public virtual string GetCurrent()
        {
            return _x.ToString() + "," + _y.ToString();
        }

        public void Increment_X()
        {
            _x = _x + 1;
        }

        public void Decrement_X()
        {
            _x = _x - 1;
        }

        public void Increment_Y()
        {
            _y = _y + 1;
        }

        public void Decrement_Y()
        {
            _y = _y - 1;
        }
    }

    public interface ILocationChangeStrategy
    {
        void MoveForward(CoOrdinates coOrdinates);

        void MoveBackward(CoOrdinates coOrdinates);
    }

    public class FacingNorth : ILocationChangeStrategy
    {
        public void MoveBackward(CoOrdinates coOrdinates)
        {
            coOrdinates.Decrement_Y();
        }

        public void MoveForward(CoOrdinates coOrdinates)
        {
            coOrdinates.Increment_Y();
        }
    }

    public class FacingSouth : ILocationChangeStrategy
    {
        public void MoveBackward(CoOrdinates coOrdinates)
        {
            coOrdinates.Increment_Y();
        }

        public void MoveForward(CoOrdinates coOrdinates)
        {
            coOrdinates.Decrement_Y();
        }
    }

    public class FacingEast : ILocationChangeStrategy
    {
        public void MoveBackward(CoOrdinates coOrdinates)
        {
            coOrdinates.Decrement_X();
        }

        public void MoveForward(CoOrdinates coOrdinates)
        {
            coOrdinates.Increment_X();
        }
    }

    public class FacingWest : ILocationChangeStrategy
    {
        public void MoveBackward(CoOrdinates coOrdinates)
        {
            coOrdinates.Increment_X();
        }

        public void MoveForward(CoOrdinates coOrdinates)
        {
            coOrdinates.Decrement_X();
        }
    }

    public class AlternativeLocationManager : ILocationManager
    {
        private IOrientationReader _orientationReader;
        private readonly int _max_X;
        private readonly int _max_Y;
        private CoOrdinates _coOrdinates;
        private readonly IDictionary<string, ILocationChangeStrategy> _strategies;

        public AlternativeLocationManager
                (
                    CoOrdinates startingCoOrdinates
                    , int max_X
                    , int max_Y
                    , IOrientationReader orientationReader
                    , IDictionary<string, ILocationChangeStrategy> strategies
                )
        {
            _coOrdinates = startingCoOrdinates;
            _max_X = max_X;
            _max_Y = max_Y;
            _orientationReader = orientationReader;
            _strategies = strategies;
        }

        public string GetCurrentLocation()
        {
            return _coOrdinates.GetCurrent();
        }

        public void MoveBackward()
        {
            _strategies[_orientationReader.GetCurrentOrientation()].MoveBackward(_coOrdinates);
        }

        public void MoveForward()
        {
            _strategies[_orientationReader.GetCurrentOrientation()].MoveForward(_coOrdinates);
        }
    }
}
