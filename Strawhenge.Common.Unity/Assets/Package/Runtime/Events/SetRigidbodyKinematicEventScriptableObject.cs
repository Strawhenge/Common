using UnityEngine;

namespace Strawhenge.Common.Unity.ScriptableObjects
{
    [CreateAssetMenu(menuName = "Strawhenge/Common/Events/SetRigidbodyKinematic")]
    public class SetRigidbodyKinematicEventScriptableObject : EventScriptableObject
    {
        [SerializeField] bool _isKinematic;

        public override void Invoke(GameObject gameObject)
        {
            if (gameObject.TryGetComponent<Rigidbody>(out var rigidbody))
                rigidbody.isKinematic = _isKinematic;
        }
    }
}