using System.IO;
using UnityEditor;

namespace Strawhenge.Common.Unity.Editor.Helpers
{
    public static class SelectionHelper
    {
        public static string GetAssetDirectoryPath()
        {
            if (Selection.activeObject == null)
                return "Assets";

            var path = AssetDatabase.GetAssetPath(Selection.activeObject);
            return AssetDatabase.IsValidFolder(path)
                ? path
                : Path.GetDirectoryName(path);
        }
    }
}