using System;

namespace Strawhenge.Common
{
    public class NullLogger : ILogger
    {
        public static NullLogger Instance { get; } = new NullLogger();

        private NullLogger()
        {
        }

        public void LogError(string message)
        {
        }

        public void LogException(Exception exception)
        {
        }

        public void LogInformation(string message)
        {
        }

        public void LogWarning(string message)
        {
        }
    }
}
