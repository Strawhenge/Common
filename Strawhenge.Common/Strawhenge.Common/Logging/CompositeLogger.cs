using System;

namespace Strawhenge.Common.Logging
{
    public class CompositeLogger : ILogger
    {
        readonly ILogger[] _loggers;

        public CompositeLogger(params ILogger[] loggers)
        {
            _loggers = loggers;
        }

        public void LogInformation(string message) => _loggers.ForEach(logger => logger.LogInformation(message));

        public void LogWarning(string message) => _loggers.ForEach(logger => logger.LogWarning(message));

        public void LogError(string message) => _loggers.ForEach(logger => logger.LogError(message));

        public void LogException(Exception exception) => _loggers.ForEach(logger => logger.LogException(exception));
    }
}