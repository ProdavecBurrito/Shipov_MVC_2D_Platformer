using UnityEngine;

namespace Shipov_Platformer_MVC
{
    public abstract class BaseBullet : IBullet
    {
        public float _timeToBack = 3.0f;
        public float _currentTime;

        protected BulletView _view;

        public BulletView GetBulletView => _view;

        public BaseBullet(BulletView view)
        {
            _currentTime = 0;
            _view = view;
            _view.SetVisible(false);
        }

        public abstract void Fly();

        public abstract void Fire(Transform fireStartTransform, Vector3 velocity);
    }
}