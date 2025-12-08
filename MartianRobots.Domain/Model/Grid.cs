namespace MartianRobots.Domain.Model
{
    internal class Grid
    {
        private readonly Coordinates lowerLeft = new(0, 0);
        private readonly Coordinates upperRight;
        private readonly HashSet<Coordinates> scents = new();
        private const int MaxCoordinate = 50;

        internal Grid(int x, int y)
        {
            if (x < 0 || x > MaxCoordinate)
                throw new ArgumentOutOfRangeException(nameof(x), $"X coordinate must be between 0 and {MaxCoordinate}");
            if (y < 0 || y > MaxCoordinate)
                throw new ArgumentOutOfRangeException(nameof(y), $"Y coordinate must be between 0 and {MaxCoordinate}");
            upperRight = new Coordinates(x, y);
        }

        internal Coordinates GetGridBoundary()
        {
            return upperRight;
        }

        internal bool IsWithinGridBounds(Coordinates coordinates)
        {
            return coordinates.X >= lowerLeft.X && coordinates.X <= upperRight.X &&
                   coordinates.Y >= lowerLeft.Y && coordinates.Y <= upperRight.Y;
        }

        internal void AddScent(Coordinates coordinates)
        {
            scents.Add(coordinates);
        }

        internal bool HasScent(Coordinates coordinates)
        {
            return scents.Contains(coordinates);
        }
    }
}
