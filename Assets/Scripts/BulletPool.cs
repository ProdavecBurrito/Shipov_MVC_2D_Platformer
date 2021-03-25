using System.Collections.Generic;
using UnityEngine;

namespace Shipov_Platformer_MVC
{
    public class BulletPool
    {
        private const float DELAY = 2;
        private const float START_SPEED = 5;

        private List<BaseBullet> _bullets;
        private Transform _fireStartPosition;

        private int _currentIndex;
        private float _timeTillNextBullet;

        public BulletPool(List<BulletView> bulletViews, string bulletType, Transform startPos)
        {
            _bullets = new List<BaseBullet>();

            foreach (var bulletView in bulletViews) // Мне кажется, тут не совсем корректно
            {
                if (bulletType == "NonPhysicBullet")
                {
                    _bullets.Add(new NonPhysicBullet(bulletView));
                }
                if (bulletType == "PhysicBullet")
                {
                    _bullets.Add(new PhysicBullet(bulletView));
                }
            }

            _currentIndex = 0;
            _fireStartPosition = startPos;
        }

        public void TryLaunchBullet()
        {
            if (_timeTillNextBullet > 0)
            {
                _timeTillNextBullet -= Time.deltaTime;
            }
            else
            {
                _timeTillNextBullet = DELAY;
                _bullets[_currentIndex].Fire(_fireStartPosition, _fireStartPosition.up * START_SPEED);
                _currentIndex++;
                if (_currentIndex >= _bullets.Count)
                {
                    if (_bullets[0].GetBulletView.IsVisible)
                    {
                        AddNewBullet();
                    }
                    else
                    {
                        _currentIndex = 0;
                    }
                }
            }
        }

        public void UpdateBullets()
        {
            _bullets.ForEach(b => b.Fly());
        }

        public void AddNewBullet()
        {
            _bullets.Add(new NonPhysicBullet(new BulletView()));
        }
    }
}
