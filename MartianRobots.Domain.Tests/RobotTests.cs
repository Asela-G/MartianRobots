using NUnit.Framework;
using MartianRobots.Domain.Model;


namespace MartianRobots.Domain.Tests
{
    [TestFixture]
    public class RobotTests
    {
        [Test]
        public void Robot_InitialPosition_And_Orientation_IsSetCorrectly()
        {
            // Arrange
            var initialPosition = new Coordinates(1, 2);
            var initialOrientation = Orientation.N;

            // Act
            var robot = new Robot(initialPosition, initialOrientation);

            // Assert
            Assert.That(robot.Coordinates, Is.EqualTo(initialPosition));
            Assert.That(robot.Orientation, Is.EqualTo(initialOrientation));
        }
    }
}
