using System;

namespace Standardly.Core.Brokers.Loggings
{
    public interface ILoggingBroker
    {
        void LogInformation(string message);
        void LogTrace(string message);
        void LogDebug(string message);
    }
}
