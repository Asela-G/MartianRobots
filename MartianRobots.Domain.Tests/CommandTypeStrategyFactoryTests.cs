using MartianRobots.Domain.Interfaces;
using MartianRobots.Domain.Model;
using NUnit.Framework;

namespace MartianRobots.Domain.Tests
{
    [TestFixture]
    public class CommandTypeStrategyFactoryTests
    {
        [Test]
        public void CommandTypeStrategyFactory_ShouldReturnCorrectStrategyInstance()
        {
            // Arrange & Act
            var leftStrategy = CommandTypeStrategyFactory.GetStrategy((CommandType)'L');
            var rightStrategy = CommandTypeStrategyFactory.GetStrategy((CommandType)'R');
            var forwardStrategy = CommandTypeStrategyFactory.GetStrategy((CommandType)'F');

            // Assert
            Assert.That(leftStrategy, Is.TypeOf<TurnLeftCommandStrategy>());
            Assert.That(rightStrategy, Is.TypeOf<TurnRightCommandStrategy>());
            Assert.That(forwardStrategy, Is.TypeOf<MoveForwardCommandStrategy>());
        }

        [Test]
        public void CommandTypeStrategyFactory_InvalidCommandTypeThrowsException()
        {
            // Arrange, Act & Assert
            Assert.That(() => CommandTypeStrategyFactory.GetStrategy((CommandType)'X'),
                Throws.TypeOf<NotImplementedException>());
        }

    }

}