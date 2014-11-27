using System.Linq;
using Robots.Contracts;

namespace Robots
{
    public class Robot : IRobot
    {
        public ILocation Location { get; set; }
        public string Heading { get; private set; }
        public ILog Log { get; set; }

        private readonly IArena _arena;

        public Robot(IArena arena, ILocation location, string heading)
        {
            Location = location;
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
            Location.Move(Heading);
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