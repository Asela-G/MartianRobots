using MartianRobots.Domain.Model;

namespace MartianRobots.Domain.Interfaces
{
    internal interface ICommandStrategy
    {
        void ProcessCommand(Robot robot, char command, Grid grid);
    }

    internal class TurnLeftCommandStrategy : ICommandStrategy
    {
        public void ProcessCommand(Robot robot, char command, Grid grid)
        {
            robot.TurnLeft();
        }
    }

    internal class TurnRightCommandStrategy : ICommandStrategy
    {
        public void ProcessCommand(Robot robot, char command, Grid grid)
        {
            robot.TurnRight();
        }
    }

    internal class MoveForwardCommandStrategy : ICommandStrategy
    {
        public void ProcessCommand(Robot robot, char command, Grid grid)
        {
            robot.MoveForward(grid);
        }
    }
}
