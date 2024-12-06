using UnityEngine;

namespace Strawhenge.Common.Unity
{
    public static class GameObjectExtensions
    {
        public static void SetLayerIncludingChildren(this GameObject gameObject, int layer)
        {
            gameObject.layer = layer;

            foreach (var child in gameObject.GetComponentsInChildren<Transform>())
                child.gameObject.layer = layer;
        }
    }
}