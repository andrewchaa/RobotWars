using Robots.Domains;

namespace Robots.Contracts
{
    public interface ITurn
    {
        string Turn(string heading, string to);
    }
}