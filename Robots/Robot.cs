using System.Linq;
using Robots.Contracts;

namespace Robots
{
    public class Robot : ITurn, IMove, IReceiveInstruction
    {
        public Location Location { get; set; }
        public string Heading { get; private set; }
        public ILog Log { get; set; }

        private readonly Arena _arena;

        public Robot(Arena arena, Location location, string heading)
        {
            Location = new Location(location);
            Heading = heading;
            _arena = arena;
            Log = new Log();
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
            Log.InfoFormat("Turned {0} to {1}", turn, Heading);
        }

        public void Move()
        {
            switch (Heading)
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

            Log.InfoFormat("Moved {0} to {1}, {2}", Heading, Location.X, Location.Y);
        }

        private void MoveNorth()
        {
            Location.Y++;
        }

        private void MoveWest()
        {
            Location.X--;
        }

        private void MoveSouth()
        {
            Location.Y--;
        }

        private void MoveEast()
        {
            Location.X++;
        }

        public void Instructions(string instructionString)
        {
            var instructions = instructionString.Select(i => i.ToString()).ToList();
            foreach (var instruction in instructions)
            {
                Log.InfoFormat("Received an instraction: {0}", instruction);
                if (instruction == "M")
                {
                    Move();
                    continue;
                }
                    
                Turn(instruction);
            }
        }
    }

}