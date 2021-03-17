using UnityEngine;

namespace Shipov_Platformer_MVC
{
    public class PhysicBullet : BaseBullet
    {
        public PhysicBullet(BulletView view) : base(view)
        {
        }

        public override void Fire(Transform fireStartTransform, Vector3 velocity)
        {
            _currentTime = 0;
            _view.CharacterTransform.position = fireStartTransform.GetChild(0).transform.position;
            _view.CharacterTransform.rotation = fireStartTransform.rotation;
            _view.CharacterRigidbody.velocity = Vector2.zero;
            _view.CharacterRigidbody.angularVelocity = 0;
            _view.SetVisible(true);
            _view.CharacterRigidbody.AddForce(velocity, ForceMode2D.Impulse);
        }

        public override void Fly()
        {
            if (_currentTime < _timeToBack)
            {
                _currentTime += Time.deltaTime;
            }
            else
            {
                ReturnToPool();
            }
        }
    }
}