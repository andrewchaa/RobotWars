namespace Robots
{
    public class Robot
    {
        public Location Location { get; set; }
        public string Direction { get; private set; }
        private Ground _ground;

        public Robot(Ground ground, Location location, string direction)
        {
            Location = location;
            Direction = direction;
            _ground = ground;
        }

        public void Turn(string turn)
        {
            switch (Direction)
            {
                case "N":
                    Direction = turn == "L" ? "W" : "E";
                    break;
                case "W":
                    Direction = turn == "L" ? "S" : "N";
                    break;
                case "S":
                    Direction = turn == "L" ? "E" : "W";
                    break;
                default:
                    Direction = turn == "L" ? "N" : "S";
                    break;
            }
        }

        public void Move()
        {
            switch (Direction)
            {
                case "N":
                    if (Location.Y == _ground.Y)
                    {
                        Location.Y = 1;
                    }
                    else
                    {
                        Location.Y++;
                    }
                    break;
                case "W":
                    if (Location.X == 1)
                    {
                        Location.X = _ground.X;
                    }
                    else
                    {
                        Location.X--;
                    }
                    break;
                case "S":
                    if (Location.Y == 1)
                    {
                        Location.Y = _ground.Y;
                    }
                    else
                    {
                        Location.Y--;
                    }
                    break;
                case "E":
                    if (Location.X == _ground.X)
                    {
                        Location.X = 1;
                    }
                    else
                    {
                        Location.X++;
                    }
                    break;
            }
        }
    }

}