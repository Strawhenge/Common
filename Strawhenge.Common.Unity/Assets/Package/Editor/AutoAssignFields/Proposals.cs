using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEditor;
using UnityEngine;

namespace Strawhenge.Common.Unity.Editor
{
    static class Proposals
    {
        public static IReadOnlyList<GameObjectProposal> Create(
            IEnumerable<GameObject> gameObjects)
        {
            var gameObjectScriptFieldAssignments = new List<GameObjectProposal>();

            foreach (GameObject gameObject in gameObjects)
            {
                if (gameObject == null)
                    continue;

                var scriptFieldAssignments = new List<ScriptProposal>();

                var monoBehaviours = gameObject.GetComponentsInChildren<MonoBehaviour>(includeInactive: true);
                foreach (var monoBehaviour in monoBehaviours)
                {
                    var serializedObject = new SerializedObject(monoBehaviour);
                    var serializedProperty = serializedObject.GetIterator();

                    var fieldAssignments = new List<FieldProposal>();

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
                            fieldAssignments.Add(new FieldProposal
                            {
                                FieldName = serializedProperty.name,
                                Value = match
                            });
                    }

                    if (fieldAssignments.Any())
                        scriptFieldAssignments.Add(new ScriptProposal
                        {
                            Script = monoBehaviour,
                            FieldProposals = fieldAssignments.ToArray()
                        });
                }

                if (scriptFieldAssignments.Any())
                    gameObjectScriptFieldAssignments.Add(
                        new GameObjectProposal
                        {
                            GameObject = gameObject,
                            ScriptProposals = scriptFieldAssignments.ToArray()
                        });
            }

            return gameObjectScriptFieldAssignments.ToArray();
        }
    }
}