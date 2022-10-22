using Strawhenge.Common.Unity.Serialization;
using UnityEditor;
using UnityEngine;

namespace Strawhenge.Common.Unity.Editor
{
    [CustomPropertyDrawer(typeof(SerializedFloatRange))]
    public class SerializedFloatRangePropertyDrawer : PropertyDrawer
    {
        static readonly string MinPropertyName = SerializedFloatRange.MinPropertyName;

        static readonly string MaxPropertyName = SerializedFloatRange.MaxPropertyName;

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            label = EditorGUI.BeginProperty(position, label, property);
            position = EditorGUI.PrefixLabel(position, label);

            var minProperty = property.FindPropertyRelative(MinPropertyName);
            var maxProperty = property.FindPropertyRelative(MaxPropertyName);

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