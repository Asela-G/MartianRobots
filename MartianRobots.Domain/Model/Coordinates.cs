namespace MartianRobots.Domain.Model
{
    internal record Coordinates(int X, int Y)
    {
        internal Coordinates MoveForward(Orientation orientation) =>
            orientation switch
            {
                Orientation.N => this with { Y = Y + 1 },
                Orientation.E => this with { X = X + 1 },
                Orientation.S => this with { Y = Y - 1 },
                Orientation.W => this with { X = X - 1 },
                _ => throw new ArgumentOutOfRangeException(nameof(orientation), orientation, null),
            };
    }
}