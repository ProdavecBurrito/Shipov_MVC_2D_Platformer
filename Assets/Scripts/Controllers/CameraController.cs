using UnityEngine;

namespace Shipov_Platformer_MVC
{
    public class CameraController : IFixedUpdate
    {
        private const float X_OFFSET = 1.5f;
        private const float CAMERA_SPEED = 3.0f;

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

        public void FixedUpdateTick()
        {
            if (_playerTransform.localScale.x < 0)
            {
                _mainCamera.position = Vector3.Lerp(_mainCamera.position,
                    _playerTransform.position.Change(_playerTransform.position.x - X_OFFSET) + _offset, CAMERA_SPEED * Time.fixedDeltaTime);

            }
            else if (_playerTransform.localScale.x > 0)
            {
                _mainCamera.position = Vector3.Lerp(_mainCamera.position,
                    _playerTransform.position.Change(_playerTransform.position.x + X_OFFSET) + _offset, CAMERA_SPEED * Time.fixedDeltaTime);
            }
        }
    }
}
