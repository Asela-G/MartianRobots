using MartianRobots.Domain.Model;
using NUnit.Framework;

namespace MartianRobots.Domain.Tests
{
    [TestFixture]
    //TODO: Add edge case tests
    public class CoordinatesTests
    {
        [SetUp]
        public void Setup()
        {
        }

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

    }
}
