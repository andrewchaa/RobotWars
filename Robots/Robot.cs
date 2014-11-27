using System.Linq;

namespace Robots
{
    public class Robot
    {
        public Location Location { get; set; }
        public string Heading { get; private set; }
        private readonly Arena _arena;

        public Robot(Arena arena, int x, int y, string heading)
        {
            Location = new Location(x, y);
            Heading = heading;
            _arena = arena;
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
            _arena.Move(this);
        }

        public void Instructions(string instructionString)
        {
            var instructions = instructionString.Select(i => i.ToString()).ToList();
            foreach (var instruction in instructions)
            {
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