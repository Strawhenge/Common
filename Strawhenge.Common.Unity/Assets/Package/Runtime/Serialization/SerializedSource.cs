using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace Strawhenge.Common.Unity.Serialization
{
    [Serializable]
    public partial class SerializedSource<T, TSerialized, TScriptableObject>
        where T : class
        where TSerialized : T, new()
        where TScriptableObject : ScriptableObject, T
    {
        [SerializeField] TSerialized _serialized;
        [SerializeField] TScriptableObject _scriptableObject;
        [SerializeField] SerializedSourceType _type;

        public bool TryGetValue(out T value)
        {
            switch (_type)
            {
                case SerializedSourceType.Serialized:
                    value = _serialized;
                    return _serialized != null;

                case SerializedSourceType.ScriptableObject:
                    value = _scriptableObject;
                    return _scriptableObject != null;

                case SerializedSourceType.None:
                default:
                    value = null;
                    return false;
            }
        }

        public T GetValue()
        {
            if (TryGetValue(out T value))
                return value;

            return new TSerialized();
        }

        public T GetValueOrDefault(Func<T> getDefault)
        {
            if (TryGetValue(out T value))
                return value;

            return getDefault();
        }
    }
}