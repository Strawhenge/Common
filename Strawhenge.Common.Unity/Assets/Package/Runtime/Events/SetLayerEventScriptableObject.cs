using UnityEngine;

namespace Strawhenge.Common.Unity.Events
{
    [CreateAssetMenu(menuName = "Strawhenge/Common/Events/SetLayer")]
    public class SetLayerEventScriptableObject : EventScriptableObject
    {
        [SerializeField] int _layer;

        public override void Invoke(GameObject gameObject)
        {
            gameObject.layer = _layer;
        }
    }
}