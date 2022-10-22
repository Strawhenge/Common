using System;
using Strawhenge.Common.Ranges;
using Strawhenge.Common.Unity.Serialization;
using UnityEngine;

[Serializable]
public class SerializedData : IData
{
    [SerializeField] int _id;
    [SerializeField] string _name;
    [SerializeField] bool _isValid;
    [SerializeField] SerializedFloatRange _range;

    public int Id => _id;

    public string Name => _name;

    public bool IsValid => _isValid;

    public FloatRange Range => _range.Value;
}