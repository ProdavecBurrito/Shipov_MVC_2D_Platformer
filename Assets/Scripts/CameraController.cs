using UnityEngine;

namespace Shipov_Platformer_MVC
{
    public class CameraController : IUpdate
    {
        private Transform _playerTransform;
        private Transform _mainCamera;
        private Vector3 _offset;

        public CameraController(Transform playerTransform, Transform mainCamera)
        {
            _playerTransform = playerTransform;
            _mainCamera = mainCamera;
            _mainCamera.LookAt(_playerTransform);
            _mainCamera.rotation = Quaternion.Euler(0, 0, 0);
            _offset = _mainCamera.position - _playerTransform.position;
        }

        public void UpdateTick()
        {
            _mainCamera.position = _playerTransform.position + _offset;
        }
    }
}
