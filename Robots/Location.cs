using Robots.Contracts;

namespace Robots
{
    public class Location : ILocation
    {
        public int X { get; set; }
        public int Y { get; set; }
        
        public ILog Log { get; set; }

        public Location(int x, int y)
        {
            X = x;
            Y = y;
            Log = new Log();
        }

        public void Move(string heading)
        {
            switch (heading)
            {
                case "N":
                    MoveNorth();
                    break;
                case "W":
                    MoveWest();
                    break;
                case "S":
                    MoveSouth();
                    break;
                case "E":
                    MoveEast();
                    break;
            }

            Log.InfoFormat("Moved {0} to {1}, {2}", heading, X, Y);
        }

        private void MoveNorth()
        {
            Y++;
        }

        private void MoveWest()
        {
            X--;
        }

        private void MoveSouth()
        {
            Y--;
        }

        private void MoveEast()
        {
            X++;
        }


        protected bool Equals(Location other)
        {
            return X == other.X && Y == other.Y;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Location)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (X * 397) ^ Y;
            }
        }
    }
}