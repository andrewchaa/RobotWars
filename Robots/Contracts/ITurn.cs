using Robots.Domains;

namespace Robots.Contracts
{
    public interface ITurn
    {
        void Turn(Robot robot, string to);
    }
}