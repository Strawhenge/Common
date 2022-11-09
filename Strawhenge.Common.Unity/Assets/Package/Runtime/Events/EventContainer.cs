using System;
using UnityEngine;

namespace Strawhenge.Common.Unity.Events
{
    [Serializable]
    public class EventContainer
    {
        [SerializeField] bool _overrideGameObject;
        [SerializeField] GameObject _gameObject;
        [SerializeField] EventScriptableObject _event;

        public void Invoke(GameObject gameObject)
        {
            if (ReferenceEquals(null, _event))
            {
                Debug.LogWarning($"'{nameof(_event)}' is missing from {nameof(EventContainer)}.", gameObject);
                return;
            }

            if (_overrideGameObject)
            {
                if (ReferenceEquals(null, _gameObject))
                {
                    Debug.LogWarning($"'{nameof(_gameObject)}' is missing from {nameof(EventContainer)}.", gameObject);
                    return;
                }

                gameObject = _gameObject;
            }

            _event.Invoke(gameObject);
        }
    }
}