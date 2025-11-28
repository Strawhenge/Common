using UnityEngine;

namespace Strawhenge.Common.Unity.Helpers
{
    public static class ComponentRefHelper
    {
        public static void EnsureHierarchyComponent<T>(ref T component, string fieldName, MonoBehaviour context)
            where T : Component
        {
            if (component != null)
                return;

            Debug.LogWarning($"'{fieldName}' not set - locating in hierarchy.", context);

            component =
                context.GetComponentInChildren<T>() ??
                context.GetComponentInChildren<T>(includeInactive: true);

            if (component != null)
                return;

            Debug.LogError($"'{typeof(T).Name}' not found in hierarchy.", context);
        }

        public static void EnsureRootHierarchyComponent<T>(ref T component, string fieldName, MonoBehaviour context)
            where T : Component
        {
            if (component != null)
                return;

            Debug.LogWarning($"'{fieldName}' not set - locating in root hierarchy.", context);

            component =
                context.GetComponentInChildren<T>() ??
                context.GetComponentInChildren<T>(includeInactive: true);

            if (component != null)
                return;

            var root = context.transform.root.gameObject;
            component =
                root.GetComponentInChildren<T>() ??
                root.GetComponentInChildren<T>(includeInactive: true);

            if (component != null)
                return;

            Debug.LogError($"'{typeof(T).Name}' not found in hierarchy.", context);
        }

        public static void EnsureSceneComponent<T>(ref T component, string fieldName, MonoBehaviour context)
            where T : Component
        {
            if (component != null)
                return;

            Debug.LogWarning($"'{fieldName}' not set - locating in scene.", context);

            component =
                Object.FindObjectOfType<T>() ??
                Object.FindObjectOfType<T>(includeInactive: true);

            if (component != null)
                return;

            Debug.LogError($"'{typeof(T).Name}' not found in scene.", context);
        }

        public static void EnsureCamera(ref UnityEngine.Camera camera, string fieldName, MonoBehaviour context)
        {
            if (camera != null)
                return;

            Debug.LogWarning($"'{fieldName}' not set - locating in scene.", context);

            camera =
                UnityEngine.Camera.main ??
                Object.FindObjectOfType<UnityEngine.Camera>() ??
                Object.FindObjectOfType<UnityEngine.Camera>(includeInactive: true);

            if (camera != null)
                return;

            Debug.LogError($"'{nameof(UnityEngine.Camera)}' not found in scene.", context);
        }
    }
}