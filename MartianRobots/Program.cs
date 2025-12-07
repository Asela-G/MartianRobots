using MartianRobots.Domain;
using MartianRobots.Domain.Model;

Console.WriteLine("Please enter the upper-right coordinate of the grid:");
var upperRightCoords = Console.ReadLine();
if (upperRightCoords == null) return;

var gridCoordinates = upperRightCoords.Split(' ');
var marsGrid = new Grid(int.Parse(gridCoordinates[0]), int.Parse(gridCoordinates[1]));

while (true)
{
    Console.WriteLine("Enter the robot position (format: X Y [N|S|E|W]):");
    var positionInput = Console.ReadLine();
    if (positionInput == null) break;//TODO: Handle input errors

    var positionParts = positionInput.Split(' ');
    if (positionParts.Length != 3) break;//TODO: Handle input errors

    var robot = new Robot(
        new Coordinates(int.Parse(positionParts[0]), int.Parse(positionParts[1])),
        Enum.Parse<Orientation>(positionParts[2])
    );

    Console.WriteLine("Enter the robot instructions (L = Turn Left, R = Turn Right and F = Move Forward):");
    var commandsInput = Console.ReadLine();
    if (commandsInput == null) break;//TODO: Handle input errors

    foreach (char command in commandsInput)
    {
        var strategy = CommandTypeStrategyFactory.GetStrategy((CommandType)command);
        strategy.ProcessCommand(robot, command, marsGrid);
    }

    var lostStatus = robot.IsLost ? "LOST" : "";
    Console.WriteLine($"Output: {robot.Coordinates.X} {robot.Coordinates.Y} {robot.Orientation} {lostStatus}");
}

