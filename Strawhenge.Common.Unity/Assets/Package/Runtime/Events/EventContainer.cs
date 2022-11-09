using System;
using UnityEngine;

namespace Strawhenge.Common.Unity.Events
{
    [Serializable]
    public class EventContainer
    {
        [SerializeField] EventScriptableObject _event;

        [SerializeField, Tooltip("Optional, will use provided GameObject if not set.")]
        GameObject _gameObject;

        public void Invoke(GameObject gameObject)
        {
            if (ReferenceEquals(null, _event))
            {
                Debug.LogWarning($"'{nameof(_event)}' is missing from {nameof(EventContainer)}.", gameObject);
                return;
            }

            if (ReferenceEquals(null, _gameObject))
            {
                _event.Invoke(gameObject);
            }
            else
            {
                _event.Invoke(_gameObject);
            }
        }
    }
}