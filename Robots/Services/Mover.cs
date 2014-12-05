using Robots.Contracts;
using Robots.Domains;
using Robots.Infrastructure;

namespace Robots.Services
{
    public class Mover : IMove
    {
        public ILog Log { get; set; }

        public Mover()
        {
            Log = new Log();
        }

        public Location Move(string heading, Location location, Arena arena)
        {
            var newLocation = new Location(location);
            switch (heading)
            {
                case "N":
                    newLocation.Y++;
                    break;

                case "W":
                    newLocation.X--;
                    break;
                
                case "S":
                    newLocation.Y--;
                    break;
                
                case "E":
                    newLocation.X++;
                    break;
            }

            arena.CheckMovability(newLocation);
            Log.InfoFormat("Moved {0} to {1}, {2}", heading, newLocation.X, newLocation.Y);

            return newLocation;
        }
    }
}