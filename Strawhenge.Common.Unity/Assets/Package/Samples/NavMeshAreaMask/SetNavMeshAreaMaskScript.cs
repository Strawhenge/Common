using UnityEngine;
using UnityEngine.AI;

namespace Strawhenge.Common.Unity
{
    public class SetNavMeshAreaMaskScript : MonoBehaviour
    {
        NavMeshAgent _navMeshAgent;

        void Awake()
        {
            _navMeshAgent = GetComponent<NavMeshAgent>();
        }
    }
}
