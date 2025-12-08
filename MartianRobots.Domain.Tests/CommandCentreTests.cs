using MartianRobots.Domain.Interfaces;
using NUnit.Framework;

namespace MartianRobots.Domain.Tests
{
    [TestFixture]
    internal class CommandCentreTests
    {
        ICommandCentre commandCentre;

        [SetUp]
        public void Setup()
        {
            commandCentre = new CommandCentre("5 3");
        }

        [Test]
        public void ExecuteRobot_ValidInputA_Returns_ExpectedResult_Within_Grid()
        {
            //Arrange & Act
            var result = commandCentre.ExecuteRobot("1 1 E", "RFRFRFRF");

            //Assert
            Assert.That(result.ToString(), Is.EqualTo("1 1 E"));
        }

        [Test]
        public void ExecuteRobot_ValidInputB_Returns_ExpectedResult_With_LOST_Coords()
        {
            //Arrange & Act
            commandCentre.ExecuteRobot("1 1 E", "RFRFRFRF");
            var result = commandCentre.ExecuteRobot("3 2 N", "FRRFLLFFRRFLL");

            //Assert
            Assert.That(result.ToString(), Is.EqualTo("3 3 N LOST"));
        }

        [Test]
        public void ExecuteRobot_CommandSeries_Results_In_Robot_Moving_Off_Edge_And_LOST()
        {
            //Arrange & Act
            commandCentre.ExecuteRobot("1 1 E", "RFRFRFRF");
            commandCentre.ExecuteRobot("3 2 N", "FRRFLLFFRRFLL");
            var result = commandCentre.ExecuteRobot("0 3 W", "LLFFFLFLFL");

            //Assert
            Assert.That(result.ToString(), Is.EqualTo("2 3 S"));
        }

        [Test]
        public void ExecuteRobot_CommandCausesRobotToFallOffGrid_MarksAsLost()
        {
            //Arrange & Act
            var result = commandCentre.ExecuteRobot("0 0 S", "F");
            //Assert
            Assert.That(result.ToString(), Is.EqualTo("0 0 S LOST"));
        }

        [Test]
        public void ExecuteRobot_InvalidCommand_ThrowsException()
        {
            //Arrange & Act & Assert
            Assert.Throws<ArgumentException>(() => commandCentre.ExecuteRobot("4 2 N", "LFLFLFFRZ"));
        }

        [Test]
        public void ExecuteRobot_StartingPositionOutOfBounds_ThrowsException()
        {
            //Arrange & Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => commandCentre.ExecuteRobot("10 14 S", "FLFLFLFFR"));
        }

        [Test]
        public void ExecuteRobot_GridBoundsOutOfRange_ThrowsException()
        {
            //Arrange & Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => new CommandCentre("50 70"));
        }


        [Test]
        public void ExecuteRobot_GridBoundsInvalidFormat_ThrowsException()
        {
            //Arrange & Act & Assert
            Assert.Throws<FormatException>(() => new CommandCentre("7"));
            Assert.Throws<FormatException>(() => new CommandCentre("3 A"));
            Assert.Throws<FormatException>(() => new CommandCentre("A B"));
        }

        [Test]
        public void ExecuteRobot_GridBoundsNegative_ThrowsException()
        {
            //Arrange & Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => new CommandCentre("-4 7"));
        }

        [Test]
        public void ExecuteRobot_NullOrEmptyCommands_ThrowsException()
        {
            //Arrange & Act & Assert
            Assert.Throws<ArgumentException>(() => commandCentre.ExecuteRobot("3 2 N", ""));
            Assert.Throws<ArgumentException>(() => commandCentre.ExecuteRobot("3 2 N", null));
        }

        [Test]
        public void ExecuteRobot_CommandsOver100Instructions_ThrowsException()
        {
            //Arrange
            var longCommandSeries = new string('F', 101);

            //Act & Assert
            Assert.Throws<ArgumentException>(() => commandCentre.ExecuteRobot("3 2 N", longCommandSeries));
        }


        [Test]
        public void ExecuteRobot_StartingPositionInvalidFormat_ThrowsException()
        {
            //Arrange & Act & Assert
            Assert.Throws<FormatException>(() => commandCentre.ExecuteRobot("2 N", "FFRFL"));
            Assert.Throws<FormatException>(() => commandCentre.ExecuteRobot("A B C", "FFRFL"));
            Assert.Throws<FormatException>(() => commandCentre.ExecuteRobot("1 2 X", "FFRFL"));
        }
    }
}
