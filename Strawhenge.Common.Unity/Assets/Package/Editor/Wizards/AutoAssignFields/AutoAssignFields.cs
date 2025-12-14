using System.Collections.Generic;
using UnityEditor;

namespace Strawhenge.Common.Unity.Editor
{
    static class AutoAssignFields
    {
        public static void Assign(IEnumerable<GameObjectProposal> proposals)
        {
            foreach (var gameObjectProposal in proposals)
            foreach (var scriptProposal in gameObjectProposal.ScriptProposals)
            {
                var serializedObject = new SerializedObject(scriptProposal.Script);

                foreach (var fieldProposal in scriptProposal.FieldProposals)
                {
                    if (!fieldProposal.Accept)
                        continue;

                    var property = serializedObject.FindProperty(fieldProposal.FieldName);
                    property.objectReferenceValue = fieldProposal.Value;
                }

                serializedObject.ApplyModifiedProperties();
                EditorUtility.SetDirty(scriptProposal.Script);
            }
        }
    }
}