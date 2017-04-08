using PlutoRover.Interfaces;

namespace PlutoRover
{
    public class LocationManager : ILocationManager
    {
        private IOrientationReader _orientationReader;
        private readonly int _max_X;
        private readonly int _max_Y;

        public LocationManager
                (
                     int origin_X
                    ,int origin_Y
                    ,int max_X
                    ,int max_Y
                    ,IOrientationReader orientationReader
                )
        {
            X = origin_X;
            Y = origin_Y;
            _max_X = max_X;
            _max_Y = max_Y;
            _orientationReader = orientationReader;
        }

        public int X
        {
            private set;
            get;
        }

        public int Y
        {
            private set;
            get;
        }

        public string GetCurrentLocation()
        {
            return X.ToString() + "," + Y.ToString();
        }

        public void MoveBackward()
        {
            var currentOrientation = _orientationReader.GetCurrentOrientation();

            switch (currentOrientation)
            {
                case "N":
                    Y = Y - 1;
                    break;
                case "E":
                    X = X - 1;
                    break;
                case "W":
                    if (X == _max_X)
                    {
                        X = -1;
                    }
                    X = X + 1;
                    break;
                case "S":
                    Y = Y + 1;
                    break;
                default:
                    break;
            }
        }

        public void MoveForward()
        {
            var currentOrientation = _orientationReader.GetCurrentOrientation();

            switch (currentOrientation)
            {
                case "N":
                    Y = Y + 1;
                    break;
                case "E":
                    if (X == _max_X)
                    {
                        X = -1;
                    }
                    X = X + 1;
                    break;
                case "W":
                    X = X - 1;
                    break;
                case "S":
                    Y = Y - 1;
                    break;
                default:
                    break;
            }
        }
    }
}
