using System.Collections.Generic;
using System.Collections.ObjectModel;
using Robots.Infrastructure;

namespace Robots.Domains
{
    public class Arena
    {
        public int Left { get; private set; } 
        public int Right { get; private set; } 
        public int Top { get; private set; }
        public int Bottom { get; private set; }
        public Log Log { get; set; }

        public ICollection<Robot> Robots { get; private set; }

        public Arena(int right, int top)
        {
            Left = 0;
            Right = right;
            Top = top;
            Bottom = 0;

            Robots = new Collection<Robot>();
            Log = new Log();
        }

        public void AddRobot(Robot robot)
        {
            Robots.Add(robot);    
        }

        public void CheckMovability(Location newLocation)
        {
            if (newLocation.Y > Top || newLocation.Y < Bottom || newLocation.X > Right || newLocation.X < Left)
            {
                Log.ErrorFormat("The robot is moving to {0}, {1}, which is outside the arena", newLocation.X, newLocation.Y);
                throw new EndOfArenaException();
            }
        }
    }
}