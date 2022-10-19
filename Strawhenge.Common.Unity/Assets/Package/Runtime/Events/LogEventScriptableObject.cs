using UnityEngine;

namespace Strawhenge.Common.Unity
{
    [CreateAssetMenu(menuName = "Strawhenge/Common/Events/Log")]
    public class LogEventScriptableObject : EventScriptableObject
    {
        [SerializeField] string _message;
        [SerializeField] LogType _logType;

        public override void Invoke(GameObject gameObject)
        {
            switch (_logType)
            {
                case LogType.Exception:
                case LogType.Error:
                    Debug.LogError(_message, gameObject);
                    break;
                case LogType.Assert:
                    Debug.LogAssertion(_message, gameObject);
                    break;
                case LogType.Warning:
                    Debug.LogWarning(_message, gameObject);
                    break;
                case LogType.Log:
                    Debug.Log(_message, gameObject);
                    break;
            }
        }
    }
}