namespace Strawhenge.Common.Unity.Serialization
{
    public partial class SerializedSource<T, TSerialized, TScriptableObject>
    {
        internal static string SerializedPropertyName => nameof(_serialized);

        internal static string ScriptableObjectPropertyName => nameof(_scriptableObject);

        internal static string TypePropertyName => nameof(_type);

        internal TSerialized Serialized
        {
            set => _serialized = value;
        }

        internal TScriptableObject ScriptableObject
        {
            set => _scriptableObject = value;
        }

        internal SerializedSourceType Type
        {
            set => _type = value;
        }
    }
}