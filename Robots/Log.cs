using System;
using Robots.Contracts;

namespace Robots
{
    public class Log : ILog
    {
        public void InfoFormat(string format, params object[] args)
        {
            Console.WriteLine(format, args);
        }
    }
}