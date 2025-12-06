using MartianRobots.Domain.Model;
using NUnit.Framework;

namespace MartianRobots.Domain.Tests
{
    [TestFixture]
    //TODO: Add edge case tests
    public class OrientationExtensionsTests
    {
        [Test]
        public void TurnLeft_ShouldReturnCorrectNewOrientation()
        {
            //Arrange, Act & Assert
            Assert.That(Orientation.N.TurnLeft(), Is.EqualTo(Orientation.W));
            Assert.That(Orientation.W.TurnLeft(), Is.EqualTo(Orientation.S));
            Assert.That(Orientation.S.TurnLeft(), Is.EqualTo(Orientation.E));
            Assert.That(Orientation.E.TurnLeft(), Is.EqualTo(Orientation.N));
        }

        [Test]
        public void TurnRight_ShouldReturnCorrectNewOrientation()
        {
            //Arrange, Act & Assert
            Assert.That(Orientation.N.TurnRight(), Is.EqualTo(Orientation.E));
            Assert.That(Orientation.E.TurnRight(), Is.EqualTo(Orientation.S));
            Assert.That(Orientation.S.TurnRight(), Is.EqualTo(Orientation.W));
            Assert.That(Orientation.W.TurnRight(), Is.EqualTo(Orientation.N));
        }
    }
}
