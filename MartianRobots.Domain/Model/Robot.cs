namespace MartianRobots.Domain.Model
{
    internal class Robot
    {
        internal Coordinates Coordinates { get; private set; }
        internal Orientation Orientation { get; private set; }
        internal Robot(Coordinates coordinates, Orientation orientation)
        {
            this.Coordinates = coordinates;
            this.Orientation = orientation;
        }

        internal void TurnLeft()
        {
            Orientation = Orientation.TurnLeft();
        }
        internal void TurnRight()
        {
            Orientation = Orientation.TurnRight();
        }
        internal void MoveForward()
        {
            Coordinates = Coordinates.MoveForward(Orientation);
        }
    }
}