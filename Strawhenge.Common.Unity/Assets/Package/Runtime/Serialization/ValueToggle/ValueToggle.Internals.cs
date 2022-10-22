namespace Strawhenge.Common.Unity.Serialization
{
    public partial class ValueToggle<T>
    {
        internal static string TogglePropertyName => nameof(_toggle);

        internal static string ValuePropertyName => nameof(_value);

        internal bool Toggle
        {
            set => _toggle = value;
        }

        internal T Value
        {
            set => _value = value;
        }
    }
}