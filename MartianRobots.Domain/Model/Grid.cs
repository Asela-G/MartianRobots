namespace MartianRobots.Domain.Model
{
    internal class Grid
    {
        private readonly Coordinates lowerLeft = new(0, 0);
        private readonly Coordinates upperRight;

        internal Grid(int x, int y)
        {
            this.upperRight = new Coordinates(x, y);
        }
    }
}
