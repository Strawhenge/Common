using UnityEngine;

namespace Strawhenge.Common.Unity
{
    public abstract class EventScriptableObject : ScriptableObject
    {
        public abstract void Invoke(GameObject gameObject);
    }
}
