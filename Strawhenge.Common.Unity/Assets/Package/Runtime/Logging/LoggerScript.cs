using System;
using Strawhenge.Common.Logging;
using UnityEngine;

namespace Strawhenge.Common.Unity
{
    public class LoggerScript : MonoBehaviour
    {
        [SerializeField] LogLevel _logLevel;

        public LogLevel LogLevel
        {
            get => _logLevel;
            set
            {
                _logLevel = value;

                if (LogLevelsDecorator != null)
                    LogLevelsDecorator.LogLevel = _logLevel;
            }
        }

        public LogLevelsDecorator LogLevelsDecorator { private get; set; }

        void Start()
        {
            LogLevelsDecorator.LogLevel = _logLevel;
        }

        public void LogInformation(string message) => LogLevelsDecorator.LogInformation(message);

        public void LogWarning(string message) => LogLevelsDecorator.LogWarning(message);

        public void LogError(string message) => LogLevelsDecorator.LogError(message);

        public void LogException(Exception exception) => LogLevelsDecorator.LogException(exception);
    }
}