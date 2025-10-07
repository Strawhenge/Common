using Strawhenge.Common.Unity.Serialization;
using UnityEngine;

namespace Strawhenge.Common.Unity
{
    public class SerializedListContainerScript : MonoBehaviour
    {
        [SerializeField] SerializedList<SampleScript> _samples;
        [SerializeField] SerializedList<Collider> _colliders;
    }
}