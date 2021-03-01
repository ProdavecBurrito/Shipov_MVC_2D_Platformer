using UnityEngine;

namespace Shipov_Platformer_MVC
{
    public class Bullet
    {
        private float _radius = 0.3f;
        private Vector3 _velocity;

        private float _groundLevel = 0;
        private float _accelerationOfGravity = -9.82f;

        private BulletView _view;

        public Bullet(BulletView view)
        {
            _view = view;
            _view.SetVisible(false);
        }

        public void Fly()
        {
            if (_view.GroundChecker.IsGrounded)
            {
                SetVelocity(_velocity.Change(y: -_velocity.y));
                _view.BulletGameObject.transform.position = _view.BulletGameObject.transform.position.Change(y: _groundLevel + _radius);
            }
            else
            {
                SetVelocity(_velocity + Vector3.up * _accelerationOfGravity * Time.deltaTime);
                _view.BulletGameObject.transform.position += _velocity * Time.deltaTime;
            }
        }

        public void Fire(Vector3 position, Vector3 velocity)
        {
            _view.BulletGameObject.transform.position = position;
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
