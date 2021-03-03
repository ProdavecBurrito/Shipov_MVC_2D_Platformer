using UnityEngine;

namespace Shipov_Platformer_MVC
{
    public class Bullet : IBullet
    {
        private float _radius = 0.3f;
        public float _timeToBack = 3.0f;
        public float _currentTime;
        private Vector3 _velocity;

        private float _accelerationOfGravity = -9.82f;

        private BulletView _view;

        public BulletView GetBulletView => _view;

        public Bullet(BulletView view)
        {
            _currentTime = 0;
            _view = view;
            _view.SetVisible(false);
        }

        public void Fly()
        {
            if (_currentTime < _timeToBack)
            {
                if (_view.GroundChecker.IsGrounded)
                {
                    SetVelocity(_velocity.Change(y: -_velocity.y));
                    _view.BulletGameObject.transform.position = _view.BulletGameObject.transform.position.Change(y: 0 + _radius);
                }
                else
                {
                    SetVelocity(_velocity + Vector3.up * _accelerationOfGravity * Time.deltaTime);
                    _view.BulletGameObject.transform.position += _velocity * Time.deltaTime;
                }
                _currentTime += Time.deltaTime;
            }
            else
            {
                _view.SetVisible(false);
                _currentTime = 0;
            }
        }

        public void Fire(Transform fireStartTransform, Vector3 velocity)
        {
            _view.BulletGameObject.transform.position = fireStartTransform.position;
            _view.BulletGameObject.transform.rotation = fireStartTransform.rotation;
            SetVelocity(velocity);
            _view.SetVisible(true);
        }

        private void SetVelocity(Vector3 velocity)
        {
            _velocity = velocity;
            var angle = Vector3.Angle(Vector3.left, _velocity);
            var axis = Vector3.Cross(Vector3.left, _velocity);
            _view.BulletGameObject.transform.rotation = Quaternion.AngleAxis(angle, axis);
        }
    }
}
