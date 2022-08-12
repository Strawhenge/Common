using UnityEngine;

namespace Strawhenge.Common.Unity.ScriptableObjects
{
    [CreateAssetMenu(menuName = "Strawhenge/Common/Events/SetRigidbodyCollisionDetectionMode")]
    public class SetRigidbodyCollisionDetectionModeEventScriptableObject : EventScriptableObject
    {
        [SerializeField] CollisionDetectionMode _collisionDetectionMode;
         
        public override void Invoke(GameObject gameObject)
        {
            if (gameObject.TryGetComponent<Rigidbody>(out var rigidbody))
                rigidbody.collisionDetectionMode = _collisionDetectionMode;
        }
    }
}
