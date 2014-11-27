using System.Linq;
using Robots.Contracts;

namespace Robots.Domains
{
    public class Robot : ITurn, IReceiveInstruction
    {
        public Location Location { get; set; }
        public string Heading { get; private set; }
        public ILog Log { get; set; }

        private readonly Arena _arena;
        private readonly IMove _mover;

        public Robot(Arena arena, Location location, string heading, IMove mover)
        {
            Location = new Location(location);
            Heading = heading;
            _arena = arena;
            _mover = mover;
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
            _mover.Move(this, _arena);
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