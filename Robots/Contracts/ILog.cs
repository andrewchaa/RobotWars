using System;

namespace Robots.Contracts
{
    public interface ILog
    {
        void InfoFormat(String format, params Object[] args);
        void ErrorFormat(String format, params Object[] args);
    }
}
