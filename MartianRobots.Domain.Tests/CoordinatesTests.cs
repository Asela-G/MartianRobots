using MartianRobots.Domain.Model;
using NUnit.Framework;

namespace MartianRobots.Domain.Tests
{
    [TestFixture]
    public class CoordinatesTests
    {

        [Test]
        public void MoveForward_North_ShouldIncreaseYCoordinate()
        {
            // Arrange
            var initialCoordinates = new Coordinates(2, 3);
            var orientation = Orientation.N;

            // Act
            var newCoordinates = initialCoordinates.MoveForward(orientation);

            // Assert
            Assert.That(newCoordinates.X, Is.EqualTo(2));
            Assert.That(newCoordinates.Y, Is.EqualTo(4));
        }

        [Test]
        public void MoveForward_East_ShouldIncreaseXCoordinate()
        {
            // Arrange
            var initialCoordinates = new Coordinates(2, 3);
            var orientation = Orientation.E;

            // Act
            var newCoordinates = initialCoordinates.MoveForward(orientation);

            // Assert
            Assert.That(newCoordinates.X, Is.EqualTo(3));
            Assert.That(newCoordinates.Y, Is.EqualTo(3));
        }

        [Test]
        public void MoveForward_South_ShouldDecreaseYCoordinate()
        {
            // Arrange
            var initialCoordinates = new Coordinates(2, 3);
            var orientation = Orientation.S;

            // Act
            var newCoordinates = initialCoordinates.MoveForward(orientation);

            // Assert
            Assert.That(newCoordinates.X, Is.EqualTo(2));
            Assert.That(newCoordinates.Y, Is.EqualTo(2));
        }

        [Test]
        public void MoveForward_West_ShouldDecreaseXCoordinate()
        {
            // Arrange
            var initialCoordinates = new Coordinates(2, 3);
            var orientation = Orientation.W;

            // Act
            var newCoordinates = initialCoordinates.MoveForward(orientation);

            // Assert
            Assert.That(newCoordinates.X, Is.EqualTo(1));
            Assert.That(newCoordinates.Y, Is.EqualTo(3));
        }

        [Test]
        public void MoveForward_MultipleMoves_ShouldUpdateCoordinatesCorrectly()
        {
            // Arrange
            var initialCoordinates = new Coordinates(1, 2);
            var orientation = Orientation.N;

            // Act
            var afterFirstMove = initialCoordinates.MoveForward(orientation);
            var afterSecondMove = afterFirstMove.MoveForward(orientation);

            // Assert
            Assert.That(afterSecondMove.X, Is.EqualTo(1));
            Assert.That(afterSecondMove.Y, Is.EqualTo(4));
        }

    }
}
