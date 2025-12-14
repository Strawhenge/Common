using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace Strawhenge.Common.Unity.Editor
{
    public class AutoAssignFieldsWizard : ScriptableWizard
    {
        const string Name = "Auto Assign Fields";

        [MenuItem("Strawhenge/Common/" + Name)]
        public static void ShowEditorWindow()
        {
            DisplayWizard<AutoAssignFieldsWizard>(Name, "Assign Fields");
        }

        [SerializeField] GameObject[] _gameObjects;

        IReadOnlyList<GameObjectProposal> _proposals;

        void OnEnable()
        {
            isValid = false;
            _gameObjects = Selection.objects
                .OfType<GameObject>()
                .Distinct()
                .ToArray();
        }

        void OnValidate() => CheckValidity();

        void OnWizardCreate()
        {
            AutoAssignFields.Assign(_proposals);
        }

        protected override bool DrawWizardGUI()
        {
            var result = base.DrawWizardGUI();

            if (GUILayout.Button("Find Fields"))
                _proposals = Proposals.Get(_gameObjects);

            if (_proposals != null)
                DisplayProposals();

            CheckValidity();
            return result;
        }

        void DisplayProposals()
        {
            foreach (var proposal in _proposals)
            {
                EditorGUILayout.Separator();
                EditorGUILayout.LabelField(proposal.GameObject.name, EditorStyles.boldLabel);

                foreach (var scriptFieldAssignment in proposal.ScriptProposals)
                {
                    EditorGUILayout.LabelField(
                        $"{scriptFieldAssignment.Script.name} ({scriptFieldAssignment.Script.GetType().Name})");

                    foreach (var fieldAssignment in scriptFieldAssignment.FieldProposals)
                    {
                        EditorGUILayout.BeginHorizontal();

                        fieldAssignment.Accept = EditorGUILayout.Toggle(fieldAssignment.Accept);
                        EditorGUILayout.LabelField(
                            $"{fieldAssignment.FieldName} => {fieldAssignment.Value.name} ({fieldAssignment.Value.GetType().Name})");

                        EditorGUILayout.EndHorizontal();
                    }
                }
            }
        }

        void CheckValidity() => isValid = _proposals != null && _proposals.Any();
    }
}