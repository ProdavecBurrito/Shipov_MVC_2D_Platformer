using System.Collections.Generic;
using UnityEngine;

namespace Shipov_Platformer_MVC
{
    public class BulletPool
    {
        private const float DELAY = 2;
        private const float START_SPEED = 5;

        private List<Bullet> _bullets = new List<Bullet>();
        private Transform _fireStartPosition;

        private int _currentIndex;
        private float _timeTillNextBullet;

        public BulletPool(List<BulletView> bulletViews, Transform transform)
        {
            if (bulletViews.Count != bulletViews.Capacity)
            {
                for (int i = 0; i < bulletViews.Capacity; i++)
                {
                    bulletViews.Add(new BulletView());
                }
            }
            _currentIndex = 0;
            _fireStartPosition = transform;
            foreach (var bulletView in bulletViews)
            {
                _bullets.Add(new Bullet(bulletView));
            }
        }

        public void TryAttack()
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
            _bullets.ForEach(b => b.Fly());
        }

        public void AddNewBullet()
        {
            _bullets.Add(new Bullet(new BulletView()));
        }
    }
}
