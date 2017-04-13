using PlutoRover.Interfaces;
using System.Collections.Generic;

namespace PlutoRover
{
    public class OrientationManager : IOrientationManager
    {
        private IOrientation _currentOrientation;
        private IDictionary<string, IOrientation> _orientations;

        public OrientationManager
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
