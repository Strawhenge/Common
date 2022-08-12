using UnityEngine;
using UnityEngine.AI;

namespace Strawhenge.Common.Unity.ScriptableObjects
{
    [CreateAssetMenu(menuName = "Strawhenge/Common/Events/EnableComponents/NavMeshObstacle")]
    public class EnableNavMeshObstacleScriptableObject : EventScriptableObject
    {
        public override void Invoke(GameObject gameObject)
        {
            if (gameObject.TryGetComponent<NavMeshObstacle>(out var navMeshObstacle))
                navMeshObstacle.enabled = true;
        }
    }
}
