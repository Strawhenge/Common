using System;

namespace Strawhenge.Common.Logging
{
    public interface ILogger
    {
        void LogInformation(string message);

        void LogWarning(string message);

        void LogError(string message);

        void LogException(Exception exception);
    }
}