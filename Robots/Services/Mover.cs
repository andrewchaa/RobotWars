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
            switch (heading)
            {
                case "N":
                    if (location.Y == arena.Top)
                    {
                        Log.ErrorFormat("The robot is currently at the top end of the arena: {0}, {1}", location.X, location.Y);
                        throw new EndOfArenaException();
                    }

                    location.Y++;
                    break;

                case "W":
                    if (location.X == arena.Left) 
                    {
                        Log.ErrorFormat("The robot is currently at the left end of the arena: {0}, {1}", location.X, location.Y);
                        throw new EndOfArenaException();
                    }

                    location.X--;
                    break;
                
                case "S":
                    if (location.Y == arena.Bottom)
                    {
                        Log.ErrorFormat("The robot is currently at the bottom end of the arena: {0}, {1}", location.X, location.Y);
                        throw new EndOfArenaException();
                    }

                    location.Y--;
                    break;
                
                case "E":
                    if (location.X == arena.Right)
                    {
                        Log.ErrorFormat("The robot is currently at the right end of the arena: {0}, {1}", location.X, location.Y);
                        throw new EndOfArenaException();
                    }

                    location.X++;
                    break;
            }

            Log.InfoFormat("Moved {0} to {1}, {2}", heading, location.X, location.Y);

            return location;
        }
    }
}