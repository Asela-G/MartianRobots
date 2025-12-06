using MartianRobots.Domain.Model;

internal static class OrientationExtensions
{
    internal static Orientation TurnLeft(this Orientation orientation)
    {
        var currentDegrees = (int)orientation;
        int newDegrees = (currentDegrees - 90 + 360) % 360;
        return (Orientation)newDegrees;
    }

    internal static Orientation TurnRight(this Orientation orientation)
    {
        var currentDegrees = (int)orientation;
        int newDegrees = (currentDegrees + 90) % 360;
        return (Orientation)newDegrees;
    }
}