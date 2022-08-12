using UnityEngine;
using UnityEngine.AI;

namespace Strawhenge.Common.Unity.ScriptableObjects
{
    [CreateAssetMenu(menuName = "Strawhenge/Common/Events/DisableComponents/NavMeshObstacle")]
    public class DisableNavMeshObstacleScriptableObject : EventScriptableObject
    {
        public override void Invoke(GameObject gameObject)
        {
            if (gameObject.TryGetComponent<NavMeshObstacle>(out var navMeshObstacle))
                navMeshObstacle.enabled = false;
        }
    }
}
