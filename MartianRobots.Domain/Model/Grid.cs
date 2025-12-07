namespace MartianRobots.Domain.Model
{
    internal class Grid
    {
        private readonly Coordinates lowerLeft = new(0, 0);
        private readonly Coordinates upperRight;
        private readonly HashSet<Coordinates> scents = new();

        internal Grid(int x, int y)
        {
            this.upperRight = new Coordinates(x, y);
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
