using Strawhenge.Common.Unity;
using Strawhenge.Common.Unity.Events;
using UnityEngine;

public class SampleEvents : MonoBehaviour
{
    [SerializeField] bool _invokeEventsOnStart;
    [SerializeField] EventScriptableObject[] _events;
    [SerializeField] EventContainer[] _eventContainers;

    [ContextMenu("Invoke Events")]
    public void InvokeEvents()
    {
        foreach (var @event in _events)
            @event.Invoke(gameObject);

        foreach (var eventContainer in _eventContainers)
            eventContainer.Invoke(gameObject);
    }

    void Start()
    {
        if (_invokeEventsOnStart)
            InvokeEvents();
    }
}