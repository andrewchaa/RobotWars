using Robots.Contracts;

namespace Robots
{
    public class Arena : IArena
    {
        public int Left { get; private set; } 
        public int Right { get; private set; } 
        public int Top { get; private set; }
        public int Bottom { get; private set; }

        public ILog Log { get; set; }

        public Arena(int right, int top)
        {
            Left = 0;
            Right = right;
            Top = top;
            Bottom = 0;

            Log = new Log();
        }
    }
}