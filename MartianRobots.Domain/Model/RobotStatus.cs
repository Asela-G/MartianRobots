namespace MartianRobots.Domain.Model
{
    public class RobotStatus
    {
        private int X { get; }
        private int Y { get; }
        private string Orientation { get; }
        private bool IsLost { get; }

        public RobotStatus(int x, int y, string orientation, bool isLost)
        {
            X = x;
            Y = y;
            Orientation = orientation;
            IsLost = isLost;
        }

        public override string ToString()
        {
            var lostStatus = IsLost ? " LOST" : "";
            return $"{X} {Y} {Orientation}{lostStatus}";
        }
    }
}
