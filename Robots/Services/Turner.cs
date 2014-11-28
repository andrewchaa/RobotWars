using System.CodeDom;
using Robots.Contracts;
using Robots.Domains;
using Robots.Infrastructure;

namespace Robots.Services
{
    public class Turner : ITurn
    {
        public ILog Log { get; set; }

        public Turner()
        {
            Log = new Log();
        }

        public string Turn(string heading, string to)
        {
            string newHeading;
            switch (heading)
            {
                case "N":
                    newHeading = to == "L" ? "W" : "E";
                    break;
                case "W":
                    newHeading = to == "L" ? "S" : "N";
                    break;
                case "S":
                    newHeading = to == "L" ? "E" : "W";
                    break;
                default:
                    newHeading = to == "L" ? "N" : "S";
                    break;
            }

            Log.InfoFormat("Turned {0} to {1}", to, newHeading);
            return newHeading;
        }
    }
}