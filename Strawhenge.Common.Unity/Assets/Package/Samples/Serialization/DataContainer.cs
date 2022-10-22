using Strawhenge.Common.Unity.Serialization;
using UnityEngine;

public class DataContainer : MonoBehaviour
{
    [SerializeField] SerializedSource<IData, SerializedData, DataScriptableObject> _data;

    public IData Data => _data.GetValue();
}