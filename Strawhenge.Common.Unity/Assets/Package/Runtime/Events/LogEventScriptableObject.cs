using UnityEngine;

namespace Strawhenge.Common.Unity
{
    [CreateAssetMenu(menuName = "Strawhenge/Common/Events/Log")]
    public class LogEventScriptableObject : EventScriptableObject
    {
        public string Message;
        public LogType LogType;

        public override void Invoke(GameObject gameObject)
        {
            switch (LogType)
            {
                case LogType.Exception:
                case LogType.Error:
                    Debug.LogError(Message, gameObject);
                    break;
                case LogType.Assert:
                    Debug.LogAssertion(Message, gameObject);
                    break;
                case LogType.Warning:
                    Debug.LogWarning(Message, gameObject);
                    break;
                case LogType.Log:
                    Debug.Log(Message, gameObject);
                    break;
            }
        }
    }
}
