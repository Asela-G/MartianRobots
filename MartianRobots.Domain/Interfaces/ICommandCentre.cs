using MartianRobots.Domain.Model;

namespace MartianRobots.Domain.Interfaces;

public interface ICommandCentre
{
    RobotStatus ExecuteRobot(string robotPosition, string commands);
}