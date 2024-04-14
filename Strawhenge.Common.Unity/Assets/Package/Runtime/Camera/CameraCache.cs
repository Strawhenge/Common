using UnityEngine;

namespace Strawhenge.Common.Unity.Camera
{
    public class CameraCache : ICameraAccessor
    {
        UnityEngine.Camera _camera;

        public UnityEngine.Camera GetCamera()
        {
            if (ReferenceEquals(_camera, null))
                _camera = Object.FindObjectOfType<UnityEngine.Camera>();

            return _camera;
        }

        public void Clear()
        {
            _camera = null;
        }
    }
}