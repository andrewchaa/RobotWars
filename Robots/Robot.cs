namespace Robots
{
    public class Robot
    {
        public Location Location { get; set; }
        public string Heading { get; private set; }
        private Ground _ground;

        public Robot(Ground ground, Location location, string heading)
        {
            Location = new Location(location.X, location.Y);
            Heading = heading;
            _ground = ground;
        }

        public void Turn(string turn)
        {
            switch (Heading)
            {
                case "N":
                    Heading = turn == "L" ? "W" : "E";
                    break;
                case "W":
                    Heading = turn == "L" ? "S" : "N";
                    break;
                case "S":
                    Heading = turn == "L" ? "E" : "W";
                    break;
                default:
                    Heading = turn == "L" ? "N" : "S";
                    break;
            }
        }

        public void Move()
        {
            _ground.Move(this);
        }
    }

}