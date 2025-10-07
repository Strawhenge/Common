using System;
using Strawhenge.Common.Unity;
using UnityEngine;

public class Context : MonoBehaviour
{
    [SerializeField] LoggerScript _loggerScript;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
            _loggerScript.Logger.LogInformation("Logging information.");

        if (Input.GetKeyDown(KeyCode.W))
            _loggerScript.Logger.LogWarning("Logging warning.");

        if (Input.GetKeyDown(KeyCode.E))
            _loggerScript.Logger.LogError("Logging error.");

        if (Input.GetKeyDown(KeyCode.X))
            _loggerScript.Logger.LogException(new Exception("Logging exception."));
    }
}