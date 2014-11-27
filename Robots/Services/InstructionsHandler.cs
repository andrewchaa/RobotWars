using System.Linq;
using Robots.Contracts;
using Robots.Domains;

namespace Robots.Services
{
    public class InstructionsHandler : IHandleInstructions
    {
        public ILog Log { get; set; }

        public InstructionsHandler()
        {
            Log = new Log();
        }

        public void Handle(Robot robot, string commandString)
        {
            var commands = commandString.Select(i => i.ToString()).ToList();
            foreach (var instruction in commands)
            {
                Log.InfoFormat("Received an instraction: {0}", instruction);
                if (instruction == "M")
                {
                    robot.Move();
                    continue;
                }

                robot.Turn(instruction);
            }

        }
    }
}