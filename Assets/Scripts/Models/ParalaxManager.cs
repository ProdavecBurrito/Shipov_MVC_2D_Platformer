using UnityEngine;

namespace Shipov_Platformer_MVC
{
    public class ParalaxManager : IUpdate
    {
        private const float _offset = 0.6f;

        private Transform _mainCamera;
        private Transform _backGround;
        private Vector3 _backStartPosition;
        private Vector3 _mainCameraStartPosition;

        public ParalaxManager(Transform camera, Transform backGround)
        {
            _mainCamera = camera;
            _backGround = backGround;
            _backStartPosition = _backGround.transform.position;
            _mainCameraStartPosition = _mainCamera.transform.position;
        }

        public void UpdateTick()
        {
            _backGround.position = _backStartPosition + (_mainCamera.position - _mainCameraStartPosition) * _offset;
        }
    }
}
