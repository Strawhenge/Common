using Strawhenge.Common.Unity.Serialization;
using UnityEditor;
using UnityEngine;

namespace Strawhenge.Common.Unity.Editor
{
    [CustomPropertyDrawer(typeof(NavMeshAreaMask))]
    public class NavMeshAreaMaskPropertyDrawer : PropertyDrawer
    {
        static readonly string[] AreaNames;

        static NavMeshAreaMaskPropertyDrawer()
        {
            AreaNames = GameObjectUtility.GetNavMeshAreaNames();
        }

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            var maskProperty = property.FindPropertyRelative(NavMeshAreaMask.ValueFieldName);

            var newMask = EditorGUI.MaskField(
                position,
                label,
                maskProperty.intValue,
                AreaNames
            );

            if (newMask != maskProperty.intValue)
            {
                maskProperty.intValue = newMask;
                property.serializedObject.ApplyModifiedProperties();
            }
        }
    }
}