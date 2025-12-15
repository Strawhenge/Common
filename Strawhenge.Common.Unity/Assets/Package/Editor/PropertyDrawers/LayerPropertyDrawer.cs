using Strawhenge.Common.Unity.Serialization;
using UnityEditor;
using UnityEngine;

namespace Strawhenge.Common.Unity.Editor
{
    [CustomPropertyDrawer(typeof(Layer))]
    public class LayerPropertyDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            var layerProperty = property.FindPropertyRelative(Layer.ValueFieldName);

            var newLayer = EditorGUI.LayerField(
                position,
                label,
                layerProperty.intValue);

            if (newLayer != layerProperty.intValue)
            {
                layerProperty.intValue = newLayer;
                property.serializedObject.ApplyModifiedProperties();
            }
        }
    }
}