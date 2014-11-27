using Robots.Contracts;
using Robots.Infrastructure;

namespace Robots.Domains
{
    public class Location
    {
        public int X { get; set; }
        public int Y { get; set; }
        
        public ILog Log { get; set; }

        public Location(Location location) : this(location.X, location.Y) { }
        public Location(int x, int y)
        {
            X = x;
            Y = y;
            Log = new Log();
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