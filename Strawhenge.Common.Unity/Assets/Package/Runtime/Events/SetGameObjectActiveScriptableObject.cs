using UnityEngine;

namespace Strawhenge.Common.Unity.Events
{
    [CreateAssetMenu(menuName = "Strawhenge/Common/Events/SetGameObjectActive")]
    public class SetGameObjectActiveScriptableObject : EventScriptableObject
    {
        [SerializeField] bool _active;

        public override void Invoke(GameObject gameObject)
        {
            gameObject.SetActive(_active);
        }
    }
}