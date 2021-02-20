using UnityEngine;

namespace Shipov_Platformer_MVC
{
    public class ParalaxManager : IUpdate
    {
        private const float _offset = 0.5f;

        private Transform _mainCamera;
        private Transform _backGround;
        private Vector3 _backStartPosition;
        private Vector3 _cameraStartPosition;

        public ParalaxManager(Transform camera, Transform backGround)
        {
            _mainCamera = camera;
            _backGround = backGround;
            _backStartPosition = _backGround.transform.position;
            _cameraStartPosition = _mainCamera.transform.position;
        }

        public void UpdateTick()
        {
            _backGround.position = _backStartPosition + (_mainCamera.position - _cameraStartPosition) * _offset;
        }
    }
}
