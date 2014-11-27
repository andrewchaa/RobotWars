using System;
using Robots.Contracts;

namespace Robots.Infrastructure
{
    public class Log : ILog
    {
        public void InfoFormat(string format, params object[] args)
        {
            Console.WriteLine("INFO - " + format, args);
        }

        public void ErrorFormat(string format, params object[] args)
        {
            Console.WriteLine("ERROR - " + format, args);
        }
    }
}