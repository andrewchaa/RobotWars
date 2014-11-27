using Robots.Domains;

namespace Robots.Contracts
{
    public interface IHandleInstructions
    {
        void Handle(Robot robot, string commandString);
    }
}