using Robots.Contracts;
using Robots.Domains;

namespace Robots.Services
{
    public class Mover : IMove
    {
        public ILog Log { get; set; }

        public Mover()
        {
            Log = new Log();
        }

        public void Move(Robot robot, Arena arena)
        {
            switch (robot.Heading)
            {
                case "N":
                    if (robot.Location.Y == arena.Top)
                    {
                        Log.ErrorFormat("The robot is currently at the top end of the arena: {0}, {1}",
                            robot.Location.X, robot.Location.Y);
                        throw new EndOfArenaException();
                    }

                    robot.Location.Y++;
                    break;
                case "W":
                    if (robot.Location.X == arena.Left) 
                    {
                        Log.ErrorFormat("The robot is currently at the left end of the arena: {0}, {1}",
                            robot.Location.X, robot.Location.Y);
                        throw new EndOfArenaException();
                    }

                    robot.Location.X--;
                    break;
                case "S":
                    if (robot.Location.Y == arena.Bottom)
                    {
                        Log.ErrorFormat("The robot is currently at the bottom end of the arena: {0}, {1}",
                            robot.Location.X, robot.Location.Y);
                        throw new EndOfArenaException();
                    }

                    robot.Location.Y--;
                    break;
                case "E":
                    if (robot.Location.X == arena.Right)
                    {
                        Log.ErrorFormat("The robot is currently at the right end of the arena: {0}, {1}",
                            robot.Location.X, robot.Location.Y);
                        throw new EndOfArenaException();
                    }

                    robot.Location.X++;
                    break;
            }

            Log.InfoFormat("Moved {0} to {1}, {2}", robot.Heading, robot.Location.X, robot.Location.Y);
            
        }
    }
}