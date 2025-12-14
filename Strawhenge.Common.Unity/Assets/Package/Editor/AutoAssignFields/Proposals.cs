using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEditor;
using UnityEngine;

namespace Strawhenge.Common.Unity.Editor
{
    static class Proposals
    {
        public static IReadOnlyList<GameObjectProposal> Create(IEnumerable<GameObject> gameObjects)
        {
            var gameObjectProposals = new List<GameObjectProposal>();

            foreach (var gameObject in gameObjects.ExcludeNull())
            {
                var scriptProposals = GetScriptProposals(gameObject);

                if (scriptProposals.Any())
                    gameObjectProposals.Add(
                        new GameObjectProposal(gameObject, scriptProposals));
            }

            return gameObjectProposals.ToArray();
        }

        static IReadOnlyList<ScriptProposal> GetScriptProposals(GameObject gameObject)
        {
            var scriptProposals = new List<ScriptProposal>();

            var scripts = gameObject
                .GetComponentsInChildren<MonoBehaviour>(includeInactive: true);

            foreach (var script in scripts)
            {
                var fieldProposals = GetFieldProposals(script, gameObject);

                if (fieldProposals.Any())
                    scriptProposals.Add(new ScriptProposal(script, fieldProposals));
            }

            return scriptProposals;
        }

        static IReadOnlyList<FieldProposal> GetFieldProposals(MonoBehaviour script, GameObject root)
        {
            var serializedObject = new SerializedObject(script);
            var serializedProperty = serializedObject.GetIterator();

            var fieldProposals = new List<FieldProposal>();

            while (serializedProperty.NextVisible(enterChildren: true))
            {
                if (serializedProperty.propertyType != SerializedPropertyType.ObjectReference)
                    continue;

                if (serializedProperty.objectReferenceValue != null)
                    continue;

                var fieldInfo = script
                    .GetType()
                    .GetField(
                        serializedProperty.name,
                        BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

                if (fieldInfo == null || !typeof(Component).IsAssignableFrom(fieldInfo.FieldType))
                    continue;

                var match = root.GetComponentInChildren(fieldInfo.FieldType, includeInactive: true);

                if (match != null)
                    fieldProposals.Add(new FieldProposal(serializedProperty.name, match));
            }

            return fieldProposals;
        }
    }
}