using System;
using UnityEditor;
using UnityEngine;

namespace Strawhenge.Common.Unity.Editor
{
    static class RemoveMissingScripts
    {
        public static void Remove(string selectedFolderPath)
        {
            var prefabGuids = AssetDatabase.FindAssets("t:Prefab", new[] { selectedFolderPath });

            var totalRemoved = 0;
            foreach (var guid in prefabGuids)
            {
                try
                {
                    var prefabPath = AssetDatabase.GUIDToAssetPath(guid);
                    var prefab = AssetDatabase.LoadAssetAtPath<GameObject>(prefabPath);
                    if (prefab == null)
                        continue;

                    var removed = 0;
                    foreach (var t in prefab.GetComponentsInChildren<Transform>(true))
                        removed += GameObjectUtility.RemoveMonoBehavioursWithMissingScript(t.gameObject);

                    if (removed <= 0)
                        continue;

                    EditorUtility.SetDirty(prefab);
                    PrefabUtility.SavePrefabAsset(prefab);

                    totalRemoved += removed;
                }
                catch (Exception exception)
                {
                    Debug.LogException(exception);
                }
            }

            AssetDatabase.SaveAssets();
            Debug.Log($"Removed {totalRemoved} missing scripts.");
        }
    }
}