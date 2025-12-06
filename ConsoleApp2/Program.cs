// See https://aka.ms/new-console-template for more information
using MartianRobots.Domain;
using MartianRobots.Domain.Model;

Console.WriteLine("Enter the upper-right coordinate of the grid on first line, followed by a pair of lines per robot representing positions (format: X Y [N|S|E|W]) and instructions (using letters L,R,F sequence):");


var upperRightCoords = Console.ReadLine();
if (upperRightCoords == null) return;

var gridCoordinates = upperRightCoords.Split(' ');
var marsGrid = new Grid(int.Parse(gridCoordinates[0]), int.Parse(gridCoordinates[1]));

while (true)
{
    var positionInput = Console.ReadLine();
    if (positionInput == null) break;//TODO: Handle input errors

    var positionParts = positionInput.Split(' ');
    if (positionParts.Length != 3) break;//TODO: Handle input errors

    var robot = new Robot(
        new Coordinates(int.Parse(positionParts[0]), int.Parse(positionParts[1])),
        Enum.Parse<Orientation>(positionParts[2])
    );

    var commandsInput = Console.ReadLine();
    if (commandsInput == null) break;//TODO: Handle input errors

    foreach (char command in commandsInput)
    {
        var strategy = CommandTypeStrategyFactory.GetStrategy((CommandType)command);
        strategy.ProcessCommand(robot, command);
    }

    Console.WriteLine($"{robot.Coordinates.X} {robot.Coordinates.Y} {robot.Orientation}");
}

