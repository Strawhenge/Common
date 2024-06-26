using System;
using Strawhenge.Common.Logging;
using UnityEngine;

namespace Strawhenge.Common.Unity
{
    public class LoggerScript : MonoBehaviour
    {
        [SerializeField] LogLevel _logLevel = LogLevel.All;

        public LogLevelsDecorator LogLevelsDecorator { private get; set; }

        void OnEnable()
        {
            LogLevelsDecorator.LogLevel = _logLevel;
        }

        void Update()
        {
            if (_logLevel != LogLevelsDecorator.LogLevel)
                LogLevelsDecorator.LogLevel = _logLevel;
        }

        public void LogInformation(string message) => LogLevelsDecorator.LogInformation(message);

        public void LogWarning(string message) => LogLevelsDecorator.LogWarning(message);

        public void LogError(string message) => LogLevelsDecorator.LogError(message);

        public void LogException(Exception exception) => LogLevelsDecorator.LogException(exception);
    }
}