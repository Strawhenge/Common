using System;

namespace Strawhenge.Common.Logging
{
    public class NullLogger : ILogger
    {
        public static NullLogger Instance { get; } = new NullLogger();

        NullLogger()
        {
        }

        public void LogInformation(string message)
        {
        }

        public void LogWarning(string message)
        {
        }

        public void LogError(string message)
        {
        }

        public void LogException(Exception exception)
        {
        }
    }
}