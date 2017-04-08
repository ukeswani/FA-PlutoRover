using PlutoRover.Interfaces;

namespace PlutoRoverTest.Dummies
{
    public class DummyOrientationReader : IOrientationReader
    {
        private string _orientation;

        public DummyOrientationReader(string orientation)
        {
            _orientation = orientation;
        }

        public string GetCurrentOrientation()
        {
            return _orientation;
        }
    }
}
