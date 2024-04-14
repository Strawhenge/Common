using UnityEngine;

namespace Strawhenge.Common.Unity
{
    public static class CameraExtensions
    {
        public static bool IsVisible(this UnityEngine.Camera camera, Transform transform) =>
            camera.IsVisible(transform.position);

        public static bool IsVisible(this UnityEngine.Camera camera, Vector3 point)
        {
            var pointToScreen = camera.WorldToViewportPoint(point);

            return pointToScreen.z >= 0 &&
                   pointToScreen.x >= 0 &&
                   pointToScreen.x <= 1 &&
                   pointToScreen.y >= 0 &&
                   pointToScreen.y <= 1;
        }
    }
}