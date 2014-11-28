using Robots.Domains;

namespace Robots.Contracts
{
    public interface IMove
    {
        Location Move(string heading, Location location, Arena arena);
    }
}