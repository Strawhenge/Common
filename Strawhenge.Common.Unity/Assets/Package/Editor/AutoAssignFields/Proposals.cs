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
            var gameObjectProposals = new List<GameObjectProposal>();

            foreach (var gameObject in gameObjects)
            {
                if (gameObject == null)
                    continue;

                var scriptProposals = new List<ScriptProposal>();

                var monoBehaviours = gameObject.GetComponentsInChildren<MonoBehaviour>(includeInactive: true);
                foreach (var monoBehaviour in monoBehaviours)
                {
                    var serializedObject = new SerializedObject(monoBehaviour);
                    var serializedProperty = serializedObject.GetIterator();

                    var fieldProposals = new List<FieldProposal>();

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
                            fieldProposals.Add(new FieldProposal
                            {
                                FieldName = serializedProperty.name,
                                Value = match
                            });
                    }

                    if (fieldProposals.Any())
                        scriptProposals.Add(new ScriptProposal
                        {
                            Script = monoBehaviour,
                            FieldProposals = fieldProposals.ToArray()
                        });
                }

                if (scriptProposals.Any())
                    gameObjectProposals.Add(
                        new GameObjectProposal
                        {
                            GameObject = gameObject,
                            ScriptProposals = scriptProposals.ToArray()
                        });
            }

            return gameObjectProposals.ToArray();
        }
    }
}