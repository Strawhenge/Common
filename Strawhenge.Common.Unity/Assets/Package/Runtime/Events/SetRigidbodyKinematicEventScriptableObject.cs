using UnityEngine;

namespace Strawhenge.Common.Unity.ScriptableObjects
{
    [CreateAssetMenu(menuName = "Strawhenge/Common/Events/SetRigidbodyKinematic")]
    public class SetRigidbodyKinematicEventScriptableObject : EventScriptableObject
    {
        public bool IsKinematic;

        public override void Invoke(GameObject gameObject)
        {
            if (gameObject.TryGetComponent<Rigidbody>(out var rigidbody))
                rigidbody.isKinematic = IsKinematic;
        }
    }
}
