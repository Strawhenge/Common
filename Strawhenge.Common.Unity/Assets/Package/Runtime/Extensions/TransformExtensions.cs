using UnityEngine;

namespace Strawhenge.Common.Unity
{
    public static class TransformExtensions
    {
        public static PositionAndRotation GetPositionAndRotation(this Transform transform)
        {
            transform.GetPositionAndRotation(out var position, out var rotation);

            return new PositionAndRotation()
            {
                Position = position,
                Rotation = rotation
            };
        }

        public static void SetPositionAndRotation(this Transform transform,
            PositionAndRotation positionAndRotation)
        {
            transform.SetPositionAndRotation(positionAndRotation.Position, positionAndRotation.Rotation);
        }
    }
}