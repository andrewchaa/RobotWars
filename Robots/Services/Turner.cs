using System.CodeDom;
using Robots.Contracts;
using Robots.Domains;

namespace Robots.Services
{
    public class Turner : ITurn
    {
        public ILog Log { get; set; }

        public Turner()
        {
            Log = new Log();
        }

        public void Turn(Robot robot, string to)
        {
            switch (robot.Heading)
            {
                case "N":
                    robot.Heading = to == "L" ? "W" : "E";
                    break;
                case "W":
                    robot.Heading = to == "L" ? "S" : "N";
                    break;
                case "S":
                    robot.Heading = to == "L" ? "E" : "W";
                    break;
                default:
                    robot.Heading = to == "L" ? "N" : "S";
                    break;
            }

            Log.InfoFormat("Turned {0} to {1}", to, robot.Heading);
            
        }
    }
}