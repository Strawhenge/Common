using System;
using UnityEngine;

[Serializable]
public class SerializedData : IData
{
    [SerializeField] int _id;
    [SerializeField] string _name;
    [SerializeField] bool _isValid;

    public int Id => _id;

    public string Name => _name;

    public bool IsValid => _isValid;
}