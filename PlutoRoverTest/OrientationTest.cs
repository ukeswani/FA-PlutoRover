using Microsoft.VisualStudio.TestTools.UnitTesting;
using PlutoRover;

namespace PlutoRoverTest
{
    [TestClass]
    public class OrientationTest
    {
        [TestMethod]
        public void OrientationNorthTurnsLeft()
        {
            var orientationUnderTest = new Orientation("N");
            var orientationToRight = new Orientation("E");
            var orientationToLeft = new Orientation("W");


            orientationUnderTest.Left = orientationToLeft;
            orientationUnderTest.Right = orientationToRight;

            var NameOfOrientationToLeft = orientationUnderTest.Left.Name;

            Assert.AreEqual("W", NameOfOrientationToLeft, "Left from North does not give Left");
        }

        [TestMethod]
        public void OrientationEastTurnsRight()
        {
            var orientationUnderTest = new Orientation("E");

            var orientationToRight = new Orientation("S");
            var orientationToLeft = new Orientation("N");


            orientationUnderTest.Left = orientationToLeft;
            orientationUnderTest.Right = orientationToRight;

            var NameOfOrientationToRight = orientationUnderTest.Right.Name;

            Assert.AreEqual("S", NameOfOrientationToRight, "Right from East does not give South");
        }
    }
}
