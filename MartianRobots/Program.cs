using MartianRobots.Domain;

Console.WriteLine("Please enter the upper-right coordinate of the grid:");
var upperRightCoords = Console.ReadLine();
if (string.IsNullOrWhiteSpace(upperRightCoords)) return;

try
{
    var commandCentre = new CommandCentre(upperRightCoords);

    while (true)
    {
        Console.WriteLine("Enter the robot starting position (Format: X Y [N|S|E|W]):");
        var positionInput = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(positionInput)) break;

        Console.WriteLine("Enter the robot instructions (L = Turn Left, R = Turn Right and F = Move Forward):");
        var commandsInput = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(commandsInput)) break;

        try
        {
            var result = commandCentre.ExecuteRobot(positionInput, commandsInput);
            Console.WriteLine($"RobotStatus: {result}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
catch (Exception ex)
{
    Console.WriteLine($"Error initializing grid: {ex.Message}");
}

