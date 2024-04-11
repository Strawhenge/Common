using System;
using Strawhenge.Common.Logging;
using Strawhenge.Common.Unity;
using UnityEngine;
using ILogger = Strawhenge.Common.Logging.ILogger;

public class Context : MonoBehaviour
{
    [SerializeField] LoggerScript _loggerScript;

    ILogger _logger;

    void Awake()
    {
        var unityLogger = new UnityLogger(gameObject);
        var decorator = new LogLevelsDecorator(unityLogger);

        _loggerScript.LogLevelsDecorator = decorator;
        _logger = decorator;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
            _logger.LogInformation("Logging information.");

        if (Input.GetKeyDown(KeyCode.W))
            _logger.LogWarning("Logging warning.");

        if (Input.GetKeyDown(KeyCode.E))
            _logger.LogError("Logging error.");

        if (Input.GetKeyDown(KeyCode.X))
            _logger.LogException(new Exception("Logging exception."));
    }
}