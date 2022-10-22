using Strawhenge.Common.Unity.Serialization;
using UnityEditor;
using UnityEngine;

namespace Strawhenge.Common.Unity.Editor
{
    [CustomPropertyDrawer(typeof(ValueToggle<>))]
    public class ValueTogglePropertyDrawer : PropertyDrawer
    {
        static readonly string TogglePropertyName = ValueToggle<int>.TogglePropertyName;

        static readonly string ValuePropertyName = ValueToggle<int>.ValuePropertyName;

        static readonly string[] menuOptions = new string[]
        {
            "Toggle On",
            "Toggle Off"
        };

        GUIStyle menuStyle;

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            menuStyle ??= new GUIStyle(GUI.skin.GetStyle("PaneOptions")) { imagePosition = ImagePosition.ImageOnly };

            label = EditorGUI.BeginProperty(position, label, property);
            position = EditorGUI.PrefixLabel(position, label);

            var menuPosition = new Rect(position);
            menuPosition.yMin += menuStyle.margin.top;
            menuPosition.width = menuStyle.fixedWidth + menuStyle.margin.right;
            position.xMin = menuPosition.xMax;

            int indent = EditorGUI.indentLevel;
            EditorGUI.indentLevel = 0;

            var valueProperty = property.FindPropertyRelative(ValuePropertyName);
            var toggleProperty = property.FindPropertyRelative(TogglePropertyName);

            var toggle = EditorGUI.Popup(menuPosition, toggleProperty.boolValue ? 0 : 1, menuOptions, menuStyle) == 0;
            toggleProperty.boolValue = toggle;

            if (toggle)
            {
                EditorGUI.PropertyField(position, valueProperty, GUIContent.none);
            }

            EditorGUI.indentLevel = indent;
            EditorGUI.EndProperty();
        }
    }
}