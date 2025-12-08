using NUnit.Framework;
using MartianRobots.Domain.Model;

namespace MartianRobots.Domain.Tests
{
    [TestFixture]
    public class RobotTests
    {
        private Grid grid;

        [SetUp]
        public void Setup()
        {
            grid = new Grid(5, 3);
        }

        [Test]
        public void InitialCoordinatesAndOrientationIsSetCorrectly()
        {
            // Arrange
            var initialPosition = new Coordinates(1, 2);
            var initialOrientation = Orientation.N;

            // Act
            var robot = new Robot(initialPosition, initialOrientation, grid);

            // Assert
            Assert.That(robot.Coordinates, Is.EqualTo(initialPosition));
            Assert.That(robot.Orientation, Is.EqualTo(initialOrientation));
        }

        [Test]
        public void TurnLeft_ChangesOrientationCorrectly()
        {
            // Arrange
            var robot = new Robot(new Coordinates(1, 2), Orientation.N, grid);

            // Act
            robot.TurnLeft();

            // Assert
            Assert.That(robot.Orientation, Is.EqualTo(Orientation.W));
        }

        [Test]
        public void TurnRight_ChangesOrientationCorrectly()
        {
            // Arrange
            var robot = new Robot(new Coordinates(1, 2), Orientation.N, grid);

            // Act
            robot.TurnRight();

            // Assert
            Assert.That(robot.Orientation, Is.EqualTo(Orientation.E));
        }

        [Test]
        public void MoveForward_UpdatesCoordinatesCorrectly()
        {
            // Arrange
            var robot = new Robot(new Coordinates(1, 2), Orientation.N, grid);

            // Act
            robot.MoveForward();

            // Assert
            Assert.That(robot.Coordinates, Is.EqualTo(new Coordinates(1, 3)));
        }

        [Test]
        public void MoveForward_OffNorthGridMarksRobotAsLost()
        {
            // Arrange
            var robot = new Robot(new Coordinates(2, 3), Orientation.N, grid);

            // Act
            robot.MoveForward();

            // Assert
            Assert.That(robot.IsLost, Is.True);
        }

        [Test]
        public void MoveForward_OffSouthGridMarksRobotAsLost()
                {
            // Arrange
            var robot = new Robot(new Coordinates(2, 0), Orientation.S, grid);

            // Act
            robot.MoveForward();

            // Assert
            Assert.That(robot.IsLost, Is.True);
        }

        [Test]
        public void MoveForward_OffEastGridMarksRobotAsLost()
        {
            // Arrange
            var robot = new Robot(new Coordinates(5, 3), Orientation.E, grid);

            // Act
            robot.MoveForward();

            // Assert
            Assert.That(robot.IsLost, Is.True);
        }

        [Test]
        public void MoveForward_OffWestGridMarksRobotAsLost()
        {
            // Arrange
            var robot = new Robot(new Coordinates(0, 2), Orientation.W, grid);

            // Act
            robot.MoveForward();

            // Assert
            Assert.That(robot.IsLost, Is.True);
        }

        [Test]
        public void FutureRobots_DoesNotGetLostOnceScentIsDetected()
        {
            // Arrange
            var robot = new Robot(new Coordinates(2, 3), Orientation.N, grid);
            robot.MoveForward();
            var robot2 = new Robot(new Coordinates(2, 3), Orientation.N, grid);

            // Act
            robot2.MoveForward();

            // Assert
            Assert.That(robot2.IsLost, Is.False);
            Assert.That(robot2.Coordinates, Is.EqualTo(new Coordinates(2, 3)));
        }

    }
}
