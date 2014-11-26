namespace Robots
{
    public class Robot
    {
        public Location Location { get; set; }
        public string Direction { get; private set; }

        public Robot(Location location, string direction)
        {
            Location = location;
            Direction = direction;
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
                    Location.Y++;
                    break;
                case "W":
                    Location.X--;
                    break;
                case "S":
                    Location.Y--;
                    break;
                case "E":
                    Location.X++;
                    break;
            }
        }
    }

}