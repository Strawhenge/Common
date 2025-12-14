using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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

        ProposedGameObjectScriptFieldAssignments[] _proposals;

        protected override bool DrawWizardGUI()
        {
            var result = base.DrawWizardGUI();

            if (GUILayout.Button("Find Fields"))
                FindFields();

            if (_proposals != null)
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

            return result;
        }

        void FindFields()
        {
            var gameObjectScriptFieldAssignments = new List<ProposedGameObjectScriptFieldAssignments>();

            foreach (GameObject gameObject in _gameObjects)
            {
                if (gameObject == null)
                    continue;

                var scriptFieldAssignments = new List<ProposedScriptFieldAssignments>();

                var monoBehaviours = gameObject.GetComponentsInChildren<MonoBehaviour>(includeInactive: true);
                foreach (var monoBehaviour in monoBehaviours)
                {
                    var serializedObject = new SerializedObject(monoBehaviour);
                    var serializedProperty = serializedObject.GetIterator();

                    var fieldAssignments = new List<ProposedFieldAssignment>();

                    while (serializedProperty.NextVisible(enterChildren: true))
                    {
                        if (serializedProperty.propertyType != SerializedPropertyType.ObjectReference)
                            continue;

                        if (serializedProperty.objectReferenceValue != null)
                            continue;

                        var fieldInfo = monoBehaviour
                            .GetType()
                            .GetField(
                                serializedProperty.name,
                                BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

                        if (fieldInfo == null || !typeof(Component).IsAssignableFrom(fieldInfo.FieldType))
                            continue;

                        var match = gameObject.GetComponentInChildren(fieldInfo.FieldType, includeInactive: true);

                        if (match != null)
                            fieldAssignments.Add(new ProposedFieldAssignment
                            {
                                Field = serializedProperty.name,
                                Match = match
                            });
                    }

                    if (fieldAssignments.Any())
                        scriptFieldAssignments.Add(new ProposedScriptFieldAssignments
                        {
                            Script = monoBehaviour,
                            FieldAssignments = fieldAssignments.ToArray()
                        });
                }

                if (scriptFieldAssignments.Any())
                    gameObjectScriptFieldAssignments.Add(
                        new ProposedGameObjectScriptFieldAssignments
                        {
                            GameObject = gameObject,
                            ScriptFieldAssignments = scriptFieldAssignments.ToArray()
                        });
            }

            _proposals = gameObjectScriptFieldAssignments.ToArray();
        }
    }
}