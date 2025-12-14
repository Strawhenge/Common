using UnityEditor;
using UnityEngine;

namespace Strawhenge.Common.Unity.Editor
{
    public class AutoAssignFieldsWizard : ScriptableWizard
    {
        const string Name = "Auto Assign Fields";

        [MenuItem("Strawhenge/" + Name)]
        public static void ShowEditorWindow()
        {
            DisplayWizard<AutoAssignFieldsWizard>(Name, "Assign Fields");
        }
    }
}