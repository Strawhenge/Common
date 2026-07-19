using Strawhenge.Common.Ranges;
using Strawhenge.Common.Unity.Serialization;
using UnityEngine;

[CreateAssetMenu(menuName = "Samples/Data")]
public class DataScriptableObject : ScriptableObject, IData
{
    [SerializeField] int _id;
    [SerializeField] string _name;
    [SerializeField] bool _isValid;
    [SerializeField] SerializedFloatRange _range;
    [SerializeField] ValueToggle<Vector3> _destination;

    public int Id => _id;

    public string Name => _name;

    public bool IsValid => _isValid;

    public FloatRange Range => _range.Value;

    public Vector3? Destination => _destination.TryGetValue(out var destination) ? destination : null;
}