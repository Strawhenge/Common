using UnityEditor;

namespace Strawhenge.Common.Unity.Editor
{
    public class RemoveMissingScriptsWizard : ScriptableWizard
    {
        const string Name = "Remove Missing Scripts";
        string _selectedFolderPath;

        [MenuItem("Strawhenge/Common/" + Name)]
        public static void ShowEditorWindow()
        {
            DisplayWizard<RemoveMissingScriptsWizard>(Name, "Remove");
        }

        void OnEnable()
        {
            RefreshSelectionState();
        }

        void OnSelectionChange()
        {
            RefreshSelectionState();
            Repaint();
        }

        protected override bool DrawWizardGUI()
        {
            var result = base.DrawWizardGUI();

            if (isValid)
                EditorGUILayout.LabelField("Selected Directory", _selectedFolderPath);

            return result;
        }

        void OnWizardCreate()
        {
            RemoveMissingScripts.Remove(_selectedFolderPath);
        }

        void RefreshSelectionState()
        {
            _selectedFolderPath = TryGetSelectedFolderPath();

            if (string.IsNullOrEmpty(_selectedFolderPath))
            {
                isValid = false;
                helpString = "Select a directory in the Project window.";
                return;
            }

            isValid = true;
            helpString = $"Selected directory: {_selectedFolderPath}";
        }

        static string TryGetSelectedFolderPath()
        {
            var selectedObject = Selection.activeObject;
            if (selectedObject == null)
                return null;

            var selectedPath = AssetDatabase.GetAssetPath(selectedObject);
            if (string.IsNullOrEmpty(selectedPath))
                return null;

            return AssetDatabase.IsValidFolder(selectedPath) ? selectedPath : null;
        }
    }
}