using System.Collections.Generic;
using Strawhenge.Common.Unity.Serialization;
using UnityEditor;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Strawhenge.Common.Unity.Editor
{
    [CustomPropertyDrawer(typeof(SerializedList<>))]
    public class SerializedListPropertyDrawer : PropertyDrawer
    {
        const string Clear = "Clear";
        const string FindInHierarchy = "Find In Hierarchy";
        const string FindInRootHierarchy = "Find In Root Hierarchy";
        const string FindInScene = "Find In Scene";

        static readonly string[] Options = new[]
        {
            Clear, FindInHierarchy, FindInRootHierarchy, FindInScene
        };

        GUIStyle _menuStyle;

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            _menuStyle ??= new GUIStyle(GUI.skin.GetStyle("PaneOptions")) { imagePosition = ImagePosition.ImageOnly };

            var menuPosition = new Rect(position);
            menuPosition.yMin += _menuStyle.margin.top;
            menuPosition.width = _menuStyle.fixedWidth + _menuStyle.margin.right;
            menuPosition.height = base.GetPropertyHeight(property, label);
            position.xMin = menuPosition.xMax;
            menuPosition.xMin -= menuPosition.width;

            var optionIndex = EditorGUI.Popup(menuPosition, -1, Options, _menuStyle);

            var valuesProperty = property.FindPropertyRelative(SerializedList<Component>.ValuesPropertyName);
            EditorGUI.PropertyField(position, valuesProperty, label);

            if (optionIndex >= 0 && optionIndex < Options.Length)
            {
                var option = Options[optionIndex];

                var componentType = fieldInfo.FieldType.GenericTypeArguments[0];
                switch (option)
                {
                    case Clear:
                        valuesProperty.ClearArray();
                        break;

                    case FindInHierarchy:
                        AppendComponents(
                            (property.serializedObject.targetObject as MonoBehaviour)?
                            .GetComponentsInChildren(componentType));
                        break;

                    case FindInRootHierarchy:
                        AppendComponents(
                            (property.serializedObject.targetObject as MonoBehaviour)?.transform.root
                            .GetComponentsInChildren(componentType));
                        break;

                    case FindInScene:
                        AppendComponents(Object.FindObjectsOfType(componentType));
                        break;
                }

                valuesProperty.serializedObject.ApplyModifiedProperties();

                void AppendComponents(IEnumerable<Object> componentsToAppend)
                {
                    var allComponents = new List<Object>();
                    for (int i = 0; i < valuesProperty.arraySize; i++)
                        allComponents.Add(valuesProperty.GetArrayElementAtIndex(i).objectReferenceValue);

                    foreach (var component in componentsToAppend)
                    {
                        if (!allComponents.Contains(component))
                            allComponents.Add(component);
                    }

                    valuesProperty.ClearArray();

                    for (var i = 0; i < allComponents.Count; i++)
                    {
                        valuesProperty.InsertArrayElementAtIndex(i);
                        valuesProperty.GetArrayElementAtIndex(i).objectReferenceValue = allComponents[i];
                    }
                }
            }
        }

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            var valuesProperty = property.FindPropertyRelative(SerializedList<Component>.ValuesPropertyName);
            return EditorGUI.GetPropertyHeight(valuesProperty);
        }
    }
}