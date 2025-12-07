using MartianRobots.Domain.Interfaces;
using MartianRobots.Domain.Model;

namespace MartianRobots.Domain
{
    internal static class CommandTypeStrategyFactory
    {
        internal static ICommandStrategy GetStrategy(CommandType commandType)
        {
            return commandType switch
            {
                CommandType.Left => new TurnLeftCommandStrategy(),
                CommandType.Right => new TurnRightCommandStrategy(),
                CommandType.Forward => new MoveForwardCommandStrategy(),
                _ => throw new NotImplementedException($"No strategy found for: {commandType}"),
            };
        }
    }
}
