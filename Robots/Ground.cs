namespace Robots
{
    public class Ground
    {
        private readonly string[,] _ground;

        public Ground(int width, int height)
        {
            _ground = new string[width, height];
        }

        public int Width { get { return _ground.GetLength(0); } }
        public int Height { get { return _ground.GetLength(1); } }

    }
}