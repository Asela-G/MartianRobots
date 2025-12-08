using MartianRobots.Domain.Interfaces;
using MartianRobots.Domain.Model;

namespace MartianRobots.Domain
{
    public class CommandCentre : ICommandCentre
    {
        private readonly Grid grid;
        private const int MaxCommandLength = 100;

        public CommandCentre(string upperRightCoords)
        {
            var (upperRightX, upperRightY) = ParseGridCoordinates(upperRightCoords);
            grid = new Grid(upperRightX, upperRightY);
        }

        public RobotStatus ExecuteRobot(string robotPosition, string commands)
        {
            var robot = ParseRobot(robotPosition);

            //Assumption made here that the robot must receive at least one command
            if (string.IsNullOrWhiteSpace(commands))
                throw new ArgumentException("Commands cannot be null or empty", nameof(commands));

            if (commands.Length > MaxCommandLength)
                throw new ArgumentException($"Commands string must be less than {MaxCommandLength} characters", nameof(commands));

            foreach (char command in commands)
            {
                if (command != 'L' && command != 'R' && command != 'F')
                    throw new ArgumentException($"Invalid command: {command}. Must be L, R, or F");

                var commandStrategy = CommandTypeStrategyFactory.GetStrategy((CommandType)command);
                commandStrategy.ProcessCommand(robot, command);
            }

            return new RobotStatus(
                robot.Coordinates.X,
                robot.Coordinates.Y,
                robot.Orientation.ToString(),
                robot.IsLost
            );
        }

        private (int X, int Y) ParseGridCoordinates(string gridBoundary)
        {
            if (string.IsNullOrWhiteSpace(gridBoundary))
                throw new ArgumentException("Grid boundary cannot be null or empty");

            var parts = gridBoundary.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            if (parts.Length != 2)
                throw new FormatException("Grid coordinates must contain exactly 2 parts: X Y");

            if (!int.TryParse(parts[0], out int x))
                throw new FormatException($"Invalid X coordinate: {parts[0]}");

            if (!int.TryParse(parts[1], out int y))
                throw new FormatException($"Invalid Y coordinate: {parts[1]}");

            return (x, y);
        }

        private Robot ParseRobot(string robotPosition)
        {
            if (string.IsNullOrWhiteSpace(robotPosition))
                throw new ArgumentException("Robot Position cannot be null or empty", nameof(robotPosition));

            var parts = robotPosition.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length != 3)
                throw new FormatException("Robot Position must contain exactly 3 parts: X Y Orientation");

            if (!int.TryParse(parts[0], out int x))
                throw new FormatException($"Invalid X coordinate: {parts[0]}");

            if (!int.TryParse(parts[1], out int y))
                throw new FormatException($"Invalid Y coordinate: {parts[1]}");

            if (!Enum.TryParse<Orientation>(parts[2], out var orientation))
                throw new FormatException($"Invalid orientation: {parts[2]}. Must be N, S, E, or W");

            return new Robot(new Coordinates(x, y), orientation, grid);
        }
    }
}
