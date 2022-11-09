using System;
using System.Collections;
using System.Collections.Generic;
using Strawhenge.Common.Unity;
using UnityEngine;

public class SampleEvents : MonoBehaviour
{
    [SerializeField] bool _invokeEventsOnStart;
    [SerializeField] EventScriptableObject[] _events;

    [ContextMenu("Invoke Events")]
    public void InvokeEvents()
    {
        foreach (var @event in _events)
            @event.Invoke(gameObject);
    }

    void Start()
    {
        if (_invokeEventsOnStart)
            InvokeEvents();
    }
}