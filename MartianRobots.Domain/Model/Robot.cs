namespace MartianRobots.Domain.Model
{
    internal class Robot
    {
        internal Coordinates Coordinates { get; private set; }
        internal Orientation Orientation { get; private set; }
        internal bool IsLost { get; private set; }
        internal Grid Grid { get; private set; }

        internal Robot(Coordinates coordinates, Orientation orientation, Grid grid)
        {
            if (!grid.IsWithinGridBounds(coordinates))
                throw new ArgumentOutOfRangeException(nameof(coordinates), "Coordinates must be within grid bounds");

            Coordinates = coordinates;
            Orientation = orientation;
            IsLost = false;
            Grid = grid;
        }

        internal void TurnLeft()
        {
            if (IsLost) return;
            Orientation = Orientation.TurnLeft();
        }
        internal void TurnRight()
        {
            if (IsLost) return;
            Orientation = Orientation.TurnRight();
        }
        internal void MoveForward()
        {
            if (IsLost) return;

            Coordinates newCoordinates = Coordinates.MoveForward(Orientation);

            if (!Grid.IsWithinGridBounds(newCoordinates))
            {
                if (!Grid.HasScent(Coordinates))
                {
                    Grid.AddScent(Coordinates);
                    IsLost = true;
                }
                return;
            }

            Coordinates = newCoordinates;
        }
    }
}