using Strawhenge.Common.Ranges;
using UnityEngine;

public interface IData
{
    int Id { get; }

    string Name { get; }

    bool IsValid { get; }

    FloatRange Range { get; }

    Vector3? Destination { get; }
}