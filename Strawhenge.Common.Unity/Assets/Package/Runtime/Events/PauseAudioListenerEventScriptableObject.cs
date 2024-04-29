using UnityEngine;

namespace Strawhenge.Common.Unity.Events
{
    [CreateAssetMenu(menuName = "Strawhenge/Common/Events/PauseAudioListener")]
    public class PauseAudioListenerEventScriptableObject : EventScriptableObject
    {
        public override void Invoke(GameObject gameObject)
        {
            AudioListener.pause = true;
        }
    }
}