using MartianRobots.Domain.Interfaces;
using MartianRobots.Domain.Model;

namespace MartianRobots.Domain
{
    internal static class CommandTypeStrategyFactory
    {
        private static readonly TurnLeftCommandStrategy TurnLeft = new();
        private static readonly TurnRightCommandStrategy TurnRight = new();
        private static readonly MoveForwardCommandStrategy MoveForward = new();

        internal static ICommandStrategy GetStrategy(CommandType commandType)
        {
            return commandType switch
            {
                CommandType.Left => TurnLeft,
                CommandType.Right => TurnRight,
                CommandType.Forward => MoveForward,
                _ => throw new NotImplementedException($"No strategy found for: {commandType}"),
            };
        }
    }
}
