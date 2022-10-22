using System;
using UnityEngine;

namespace Strawhenge.Common.Unity.Serialization
{
    [Serializable]
    public class SerializedSource<T, TSerialized, TScriptableObject>
        where T : class
        where TSerialized : T, new()
        where TScriptableObject : ScriptableObject, T
    {
        public TSerialized Serialized;
        public TScriptableObject ScriptableObject;
        public SerializedSourceType Type;

        public bool TryGetValue(out T value)
        {
            switch (Type)
            {
                case SerializedSourceType.Serialized:
                    value = Serialized;
                    return Serialized != null;

                case SerializedSourceType.ScriptableObject:
                    value = ScriptableObject;
                    return ScriptableObject != null;

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

    public enum SerializedSourceType
    {
        None = 0,
        Serialized = 1,
        ScriptableObject = 2
    }
}