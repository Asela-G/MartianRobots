using MartianRobots.Domain.Model;

namespace MartianRobots.Domain.Interfaces
{
    internal interface ICommandStrategy
    {
        void ProcessCommand(Robot robot, char command);
    }

    internal class TurnLeftCommandStrategy : ICommandStrategy
    {
        public void ProcessCommand(Robot robot, char command)
        {
            robot.TurnLeft();
        }
    }

    internal class TurnRightCommandStrategy : ICommandStrategy
    {
        public void ProcessCommand(Robot robot, char command)
        {
            robot.TurnRight();
        }
    }

    internal class MoveForwardCommandStrategy : ICommandStrategy
    {
        public void ProcessCommand(Robot robot, char command)
        {
            robot.MoveForward();
        }
    }
}
