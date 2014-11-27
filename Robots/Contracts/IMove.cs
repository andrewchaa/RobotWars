using Robots.Domains;

namespace Robots.Contracts
{
    public interface IMove
    {
        void Move(Robot robot, Arena arena);
    }
}