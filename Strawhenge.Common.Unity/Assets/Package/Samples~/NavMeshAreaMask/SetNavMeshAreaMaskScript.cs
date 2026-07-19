using Strawhenge.Common.Unity.Serialization;
using UnityEngine;
using UnityEngine.AI;

namespace Strawhenge.Common.Unity
{
    public class SetNavMeshAreaMaskScript : MonoBehaviour
    {
        [SerializeField] NavMeshAreaMask _areaMask;

        NavMeshAgent _navMeshAgent;

        void Awake()
        {
            _navMeshAgent = GetComponent<NavMeshAgent>();
        }

        void Update()
        {
            _navMeshAgent.areaMask = _areaMask.Value;
        }
    }
}