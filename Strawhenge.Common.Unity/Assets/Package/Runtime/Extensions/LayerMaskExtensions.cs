using UnityEngine;

namespace Strawhenge.Common.Unity
{
    public static class LayerMaskExtensions
    {
        public static bool ContainsLayer(this LayerMask layerMask, int layer) => 
            layerMask == (layerMask | (1 << layer));
    }
}