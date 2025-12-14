using System.Collections.Generic;
using UnityEditor;

namespace Strawhenge.Common.Unity.Editor
{
    static class AutoAssignFields
    {
        public static void Assign(IEnumerable<ProposedGameObjectScriptFieldAssignments> proposals)
        {
            foreach (var gameObjectProposal in proposals)
            {
                foreach (var scriptProposal in gameObjectProposal.ScriptFieldAssignments)
                {
                    var serializedObject = new SerializedObject(scriptProposal.Script);

                    foreach (var fieldProposal in scriptProposal.FieldAssignments)
                    {
                        if (!fieldProposal.Accept)
                            continue;

                        var property = serializedObject.FindProperty(fieldProposal.Field);
                        property.objectReferenceValue = fieldProposal.Match;
                    }

                    serializedObject.ApplyModifiedProperties();
                    EditorUtility.SetDirty(scriptProposal.Script);
                }
            }
        }
    }
}