using System;

namespace Strawhenge.Common.Logging
{
    public class LogLevelsDecorator : ILogger
    {
        readonly ILogger _innerLogger;
        readonly Func<LogLevel> _getLogLevel;

        public LogLevelsDecorator(ILogger innerLogger, Func<LogLevel> getLogLevel)
        {
            _innerLogger = innerLogger;
            _getLogLevel = getLogLevel;
        }
        
        LogLevel LogLevel => _getLogLevel();

        public void LogInformation(string message)
        {
            if (LogLevel.HasFlag(LogLevel.Information))
                _innerLogger.LogInformation(message);
        }

        public void LogWarning(string message)
        {
            if (LogLevel.HasFlag(LogLevel.Warning))
                _innerLogger.LogWarning(message);
        }

        public void LogError(string message)
        {
            if (LogLevel.HasFlag(LogLevel.Error))
                _innerLogger.LogError(message);
        }

        public void LogException(Exception exception)
        {
            if (LogLevel.HasFlag(LogLevel.Error))
                _innerLogger.LogException(exception);
        }
    }
}