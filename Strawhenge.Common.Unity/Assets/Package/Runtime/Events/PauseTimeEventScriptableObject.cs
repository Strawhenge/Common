using UnityEngine;

namespace Strawhenge.Common.Unity.Events
{
    [CreateAssetMenu(menuName = "Strawhenge/Common/Events/PauseTime")]
    public class PauseTimeEventScriptableObject : EventScriptableObject
    {
        public override void Invoke(GameObject gameObject)
        {
            Time.timeScale = 0;
        }
    }
}