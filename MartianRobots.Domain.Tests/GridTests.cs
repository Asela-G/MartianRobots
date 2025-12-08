using MartianRobots.Domain.Model;
using NUnit.Framework;

namespace MartianRobots.Domain.Tests
{
    [TestFixture]
    public class GridTests
    {
        [Test]
        public void Initialisation_SetsGridBoundaryCorrectly()
        {
            // Arrange & Act
            var grid = new Grid(5, 3);

            // Assert
            Assert.That(grid.GetGridBoundary().X, Is.EqualTo(5));
            Assert.That(grid.GetGridBoundary().Y, Is.EqualTo(3));
        }

        [Test]
        public void IsWithinBounds_ReturnsTrueForCoordinatesInsideGrid()
        {
            // Arrange
            var grid = new Grid(5, 3);
            var coordinates = new Coordinates(2, 2);

            // Act
            var result = grid.IsWithinGridBounds(coordinates);

            // Assert
            Assert.That(result, Is.True);
        }

        [Test]
        public void IsWithinBounds_ReturnsFalseForCoordinatesOutsideGrid()
        {
            // Arrange
            var grid = new Grid(5, 3);
            var coordinates = new Coordinates(6, 4);

            // Act
            var result = grid.IsWithinGridBounds(coordinates);

            // Assert
            Assert.That(result, Is.False);
        }

        [Test]
        public void IsWithinBounds_ReturnsFalseForNegativeCoordinates()
        {
            // Arrange
            var grid = new Grid(5, 3);
            var coordinates = new Coordinates(-1, 2);

            // Act
            var result = grid.IsWithinGridBounds(coordinates);

            // Assert
            Assert.That(result, Is.False);
        }

        [Test]
        public void IsWithinBounds_ReturnsTrueForCoordinatesOnGridEdge()
        {
            // Arrange
            var grid = new Grid(5, 3);
            var coordinates = new Coordinates(5, 3);

            // Act
            var result = grid.IsWithinGridBounds(coordinates);

            // Assert
            Assert.That(result, Is.True);
        }
    }
}