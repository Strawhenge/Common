using System;
using System.Collections.Generic;
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

        [SerializeField] GameObject[] _gameObjects;

        IReadOnlyList<ProposedGameObjectScriptFieldAssignments> _proposals;

        void OnWizardCreate()
        {
            AutoAssignFields.Assign(_proposals);
        }

        protected override bool DrawWizardGUI()
        {
            var result = base.DrawWizardGUI();

            if (GUILayout.Button("Find Fields"))
                _proposals = Proposals.Create(_gameObjects);

            if (_proposals != null)
                DisplayProposals();

            return result;
        }

        void DisplayProposals()
        {
            foreach (var proposal in _proposals)
            {
                EditorGUILayout.LabelField(proposal.GameObject.name, EditorStyles.boldLabel);

                foreach (var scriptFieldAssignment in proposal.ScriptFieldAssignments)
                {
                    EditorGUILayout.LabelField(
                        $"{scriptFieldAssignment.Script.name} ({scriptFieldAssignment.Script.GetType().Name})");

                    foreach (var fieldAssignment in scriptFieldAssignment.FieldAssignments)
                    {
                        EditorGUILayout.BeginHorizontal();

                        fieldAssignment.Accept = EditorGUILayout.Toggle(fieldAssignment.Accept);
                        EditorGUILayout.LabelField(
                            $"{fieldAssignment.Field} => {fieldAssignment.Match.name} ({fieldAssignment.Match.GetType().Name})");

                        EditorGUILayout.EndHorizontal();
                    }
                }
            }
        }
    }
}