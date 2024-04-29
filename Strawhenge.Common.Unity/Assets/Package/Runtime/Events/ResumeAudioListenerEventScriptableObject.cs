using UnityEngine;

namespace Strawhenge.Common.Unity.Events
{
    [CreateAssetMenu(menuName = "Strawhenge/Common/Events/ResumeAudioListener")]
    public class ResumeAudioListenerEventScriptableObject : EventScriptableObject
    {
        public override void Invoke(GameObject gameObject)
        {
            AudioListener.pause = false;
        }
    }
}