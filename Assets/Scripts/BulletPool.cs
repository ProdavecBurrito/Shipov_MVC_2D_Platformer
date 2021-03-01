using System.Collections.Generic;
using UnityEngine;

namespace Shipov_Platformer_MVC
{
    public class BulletPool
    {
        private const float DELAY = 1;
        private const float START_SPEED = 5;

        private List<Bullet> _bullets = new List<Bullet>();
        private Transform _fireStartPosition;

        private int _currentIndex;
        private float _timeTillNextBullet;

        public BulletPool(List<BulletView> bulletViews, Transform transform)
        {
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
                _bullets[_currentIndex].Fire(_fireStartPosition.position, _fireStartPosition.up * START_SPEED);
                _currentIndex++;
                if (_currentIndex >= _bullets.Count)
                {
                    _currentIndex = 0;
                }
            }
            _bullets.ForEach(b => b.Fly());
        }
    }
}
