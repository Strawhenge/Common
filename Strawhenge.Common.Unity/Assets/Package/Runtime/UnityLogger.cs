using System;
using UnityEngine;
using ILogger = Strawhenge.Common.Logging.ILogger;

namespace Strawhenge.Common.Unity
{
    public class UnityLogger : ILogger
    {
        readonly GameObject _gameObject;

        public UnityLogger(GameObject gameObject)
        {
            _gameObject = gameObject;
        }

        public void LogError(string message)
        {
            Debug.LogError(message, _gameObject);
        }

        public void LogException(Exception exception)
        {
            Debug.LogException(exception, _gameObject);
        }

        public void LogInformation(string message)
        {
            Debug.Log(message, _gameObject);
        }

        public void LogWarning(string message)
        {
            Debug.LogWarning(message, _gameObject);
        }
    }
}