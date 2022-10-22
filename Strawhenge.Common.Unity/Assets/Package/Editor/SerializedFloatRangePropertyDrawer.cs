using Strawhenge.Common.Unity.Serialization;
using UnityEditor;
using UnityEngine;

namespace Strawhenge.Common.Unity.Editor
{
    [CustomPropertyDrawer(typeof(SerializedFloatRange))]
    public class SerializedFloatRangePropertyDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            label = EditorGUI.BeginProperty(position, label, property);
            position = EditorGUI.PrefixLabel(position, label);

            var minProperty = property.FindPropertyRelative(SerializedFloatRange.Min);
            var maxProperty = property.FindPropertyRelative(SerializedFloatRange.Max);

            if (minProperty.floatValue > maxProperty.floatValue)
                maxProperty.floatValue = minProperty.floatValue;

            var indentation = EditorGUI.indentLevel;
            EditorGUI.indentLevel = 0;

            position.width = position.width / 2 - indentation;
            EditorGUI.PropertyField(position, minProperty, GUIContent.none);

            position.x += position.width + indentation * 2;
            EditorGUI.PropertyField(position, maxProperty, GUIContent.none);
        }
    }
}