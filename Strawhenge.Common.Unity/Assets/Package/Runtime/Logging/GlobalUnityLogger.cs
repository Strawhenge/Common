using System;
using UnityEngine;
using ILogger = Strawhenge.Common.Logging.ILogger;

namespace Strawhenge.Common.Unity
{
    public class GlobalUnityLogger : ILogger
    {
        public static GlobalUnityLogger Instance { get; } = new();

        GlobalUnityLogger()
        {
        }

        public void LogInformation(string message)
        {
            Debug.Log(message);
        }

        public void LogWarning(string message)
        {
            Debug.LogWarning(message);
        }

        public void LogError(string message)
        {
            Debug.LogError(message);
        }

        public void LogException(Exception exception)
        {
            Debug.LogException(exception);
        }
    }
}