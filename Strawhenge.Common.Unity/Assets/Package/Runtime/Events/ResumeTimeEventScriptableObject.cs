using UnityEngine;

namespace Strawhenge.Common.Unity.Events
{
    [CreateAssetMenu(menuName = "Strawhenge/Common/Events/ResumeTime")]
    public class ResumeTimeEventScriptableObject : EventScriptableObject
    {
        public override void Invoke(GameObject gameObject)
        {
            Time.timeScale = 1;
        }
    }
}