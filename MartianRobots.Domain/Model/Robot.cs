namespace MartianRobots.Domain.Model
{
    internal class Robot
    {
        internal Coordinates Coordinates { get; private set; }
        internal Orientation Orientation { get; private set; }
        internal bool IsLost { get; private set; }

        internal Robot(Coordinates coordinates, Orientation orientation)
        {
            this.Coordinates = coordinates;
            this.Orientation = orientation;
            this.IsLost = false;
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
        internal void MoveForward(Grid grid)
        {
            if (IsLost) return;

            Coordinates newCoordinates = Coordinates.MoveForward(Orientation);

            if (!grid.IsWithinGridBounds(newCoordinates))
            {
                if (!grid.HasScent(Coordinates))
                {
                    grid.AddScent(Coordinates);
                    IsLost = true;
                }
                return;
            }

            Coordinates = newCoordinates;
        }
    }
}