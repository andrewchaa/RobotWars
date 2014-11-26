namespace Robots
{
    public class Ground
    {
        private readonly string[,] _ground;

        public Ground(int x, int y)
        {
            _ground = new string[x, y];
        }

        public int X { get { return _ground.GetLength(0); } }
        public int Y { get { return _ground.GetLength(1); } }
        public Robot Robot { get; set; }
    }
}