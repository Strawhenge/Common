using Strawhenge.Common.Logging;
using UnityEngine;
using ILogger = Strawhenge.Common.Logging.ILogger;

namespace Strawhenge.Common.Unity
{
    public class LoggerScript : MonoBehaviour
    {
        [SerializeField] LogLevel _logLevel = LogLevel.All;

        ILogger _logger;

        public ILogger Logger => _logger ??= CreateLogger();

        void Awake()
        {
            _logger ??= CreateLogger();
        }

        ILogger CreateLogger()
        {
            return new LogLevelsDecorator(
                innerLogger: new UnityLogger(gameObject),
                getLogLevel: () => _logLevel);
        }
    }
}