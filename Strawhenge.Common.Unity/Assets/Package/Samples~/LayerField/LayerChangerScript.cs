using Strawhenge.Common.Unity.Serialization;
using UnityEngine;

public class LayerChangerScript : MonoBehaviour
{
    [SerializeField] Layer _layer;

    void Update()
    {
        gameObject.layer = _layer.Value;
    }
}
