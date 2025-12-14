using UnityEditor;
using UnityEngine;

namespace Strawhenge.Common.Unity.Editor
{
    public class PrefabReplacerWizard : ScriptableWizard
    {
        const string Name = "Prefab Replacer";

        [MenuItem("Strawhenge/Common/" + Name)]
        public static void ShowEditorWindow()
        {
            DisplayWizard<PrefabReplacerWizard>(Name, "Replace");
        }

        [SerializeField] GameObject[] _searchIn;
        [SerializeField] PrefabMapping[] _prefabMapping;

        void OnWizardCreate()
        {
            PrefabReplacer.Replace(_searchIn, _prefabMapping);
        }
    }
}