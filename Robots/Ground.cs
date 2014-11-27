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

        public void Move(Robot robot)
        {
            switch (robot.Heading)
            {
                case "N":
                    robot.Location.Y++;
                    break;
                case "W":
                    robot.Location.X--;
                    break;
                case "S":
                    robot.Location.Y--;
                    break;
                case "E":
                    robot.Location.X++;
                    break;
            }

        }
    }
}