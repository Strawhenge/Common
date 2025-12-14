using UnityEditor;
using UnityEngine;
using Object = UnityEngine.Object;
using Strawhenge.Common.Unity.Serialization;

namespace Strawhenge.Common.Unity.Editor
{
    [CustomPropertyDrawer(typeof(SerializedSource<,,>))]
    public class SerializedSourcePropertyDrawer : PropertyDrawer
    {
        static readonly string SerializedPropertyName =
            SerializedSource<Object, Object, ScriptableObject>.SerializedPropertyName;

        static readonly string ScriptableObjectPropertyName =
            SerializedSource<Object, Object, ScriptableObject>.ScriptableObjectPropertyName;

        static readonly string TypePropertyName =
            SerializedSource<Object, Object, ScriptableObject>.TypePropertyName;

        GUIStyle _menuStyle;

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            _menuStyle ??= new GUIStyle(GUI.skin.GetStyle("PaneOptions")) { imagePosition = ImagePosition.ImageOnly };
            var initialPosition = position;

            var serializedProperty = property.FindPropertyRelative(SerializedPropertyName);
            var scriptableObjectProperty = property.FindPropertyRelative(ScriptableObjectPropertyName);
            var typeProperty = property.FindPropertyRelative(TypePropertyName);

            label = EditorGUI.BeginProperty(position, label, property);
            position = EditorGUI.PrefixLabel(position, label);

            var menuPosition = new Rect(position);
            menuPosition.yMin += _menuStyle.margin.top;
            menuPosition.width = _menuStyle.fixedWidth + _menuStyle.margin.right;
            position.xMin = menuPosition.xMax;
            menuPosition.height = base.GetPropertyHeight(property, label);

            int indent = EditorGUI.indentLevel;
            EditorGUI.indentLevel = 0;

            var option = (SerializedSourceType)EditorGUI
                .Popup(menuPosition, typeProperty.enumValueIndex, typeProperty.enumDisplayNames, _menuStyle);
            
            typeProperty.enumValueIndex = (int)option;

            switch (option)
            {
                case SerializedSourceType.ScriptableObject:
                    EditorGUI.PropertyField(position, scriptableObjectProperty, GUIContent.none);
                    break;

                case SerializedSourceType.Serialized:
                    EditorGUI.indentLevel = indent;
                    EditorGUI.PropertyField(initialPosition, serializedProperty, GUIContent.none,
                        includeChildren: true);
                    break;
            }

            EditorGUI.indentLevel = indent;
            EditorGUI.EndProperty();
        }

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            var typeProperty = property.FindPropertyRelative(TypePropertyName);
            var type = (SerializedSourceType)typeProperty.enumValueIndex;

            if (type != SerializedSourceType.Serialized)
                return base.GetPropertyHeight(property, label);

            var serializedProperty = property.FindPropertyRelative(SerializedPropertyName);
            return EditorGUI.GetPropertyHeight(serializedProperty);
        }
    }
}