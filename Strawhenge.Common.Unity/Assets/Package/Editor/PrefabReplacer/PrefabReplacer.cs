using System.Linq;
using UnityEditor;
using UnityEngine;

namespace Strawhenge.Common.Unity.Editor
{
    static class PrefabReplacer
    {
        public static void Replace(GameObject[] searchIn, PrefabMapping[] prefabMapping)
        {
            var allGameObjects = searchIn
                .SelectMany(g => g.GetComponentsInChildren<Transform>())
                .Select(t => t.gameObject)
                .ToArray();

            foreach (var gameObject in allGameObjects)
            {
                if (!PrefabUtility.IsAnyPrefabInstanceRoot(gameObject))
                    continue;

                foreach (var mapping in prefabMapping)
                {
                    if (PrefabUtility.GetCorrespondingObjectFromSource(gameObject) == mapping.OriginalPrefab)
                    {
                        ReplaceInstance(gameObject, mapping.ReplacementPrefab);
                        break;
                    }
                }
            }
        }

        static void ReplaceInstance(GameObject gameObject, GameObject replacementPrefab)
        {
            var parent = gameObject.transform.parent;
            var position = gameObject.transform.position;
            var rotation = gameObject.transform.rotation;
            var scale = gameObject.transform.localScale;

            Object.DestroyImmediate(gameObject);

            var newInstance = (GameObject)PrefabUtility.InstantiatePrefab(replacementPrefab);

            newInstance.transform.parent = parent;
            newInstance.transform.position = position;
            newInstance.transform.rotation = rotation;
            newInstance.transform.localScale = scale;

            EditorUtility.SetDirty(newInstance);
        }
    }
}