using System.Collections.Generic;
using UnityEngine;

namespace Shipov_Platformer_MVC
{
    public class References
    {
        private const int BULLETS_COUNT = 5;

        private PlayerView _playerView;
        private List<LevelObjectView> _coins;
        private List<BulletView> _bullets;
        private List<DeathTrigger> _deathTriggers;
        private List<WinTrigger> _winTriggers;
        private List<ExplosionView> _cannonExplosions;
        private List<SpriteAnimator> _explosionsSpriteAnimators;

        public List<SpriteAnimator> GetExposionsSpriteAnimators => _explosionsSpriteAnimators;

        public PlayerView GetPlayer
        {
            get
            {
                if (_playerView == null)
                {
                    PlayerView loadingPlayer = Resources.Load<PlayerView>("Player");
                    _playerView = Object.Instantiate(loadingPlayer);
                }

                return _playerView;
            }
        }

        public List<LevelObjectView> GetCoins
        {
            get
            {
                if (_coins == null)
                {
                    _coins = new List<LevelObjectView>();
                    var coins = Resources.Load<GameObject>("Coins");
                    var coinsInst = Object.Instantiate(coins);
                    var coinsDivider = coinsInst.GetComponentsInChildren<LevelObjectView>();
                    foreach (var item in coinsDivider)
                    {
                        _coins.Add(item);
                    }
                }

                return _coins;
            }
        }

        public List<BulletView> GetBulletViews
        {
            get
            {
                if (_bullets == null)
                {
                    _bullets = new List<BulletView>(BULLETS_COUNT);
                    for (int i = 0; i < _bullets.Capacity; i++)
                    {
                        var bullet = Resources.Load<BulletView>("CannonBullet");
                        var bulletInst = Object.Instantiate(bullet);
                        _bullets.Add(bulletInst);
                    }
                }
                return _bullets;
            }
        }

        public List<DeathTrigger> GetDeathTriggers
        {
            get
            {
                if (_deathTriggers == null)
                {
                    _deathTriggers = new List<DeathTrigger>();
                    var inst = GameObject.FindObjectsOfType<DeathTrigger>();
                    foreach (var item in inst)
                    {
                        _deathTriggers.Add(item);
                    }
                }
                return _deathTriggers;
            }
        }

        public List<WinTrigger> GetWindZones
        {
            get
            {
                if (_winTriggers == null)
                {
                    _winTriggers = new List<WinTrigger>();
                    var inst = GameObject.FindObjectsOfType<WinTrigger>();
                    foreach (var item in inst)
                    {
                        _winTriggers.Add(item);
                    }
                }
                return _winTriggers;
            }
        }

        public List<ExplosionView> GetCannonExplosions
        {
            get
            {
                if (_cannonExplosions == null)
                {
                    _cannonExplosions = new List<ExplosionView>(BULLETS_COUNT);
                    for (int i = 0; i < _bullets.Capacity; i++)
                    {
                        var explosion = Resources.Load<ExplosionView>("CannonBulletExplosion");
                        var explosionInst = Object.Instantiate(explosion);
                        _cannonExplosions.Add(explosionInst);
                    }
                }
                return _cannonExplosions;
            }
        }

        public List<SpriteAnimator> GetExplosionAnimators(SpriteAnimationCnfg spriteAnimationCnfg)
        {
            if (_explosionsSpriteAnimators == null)
            {
                _explosionsSpriteAnimators = new List<SpriteAnimator>(BULLETS_COUNT);
                for (int i = 0; i < _explosionsSpriteAnimators.Capacity; i++)
                {
                    _explosionsSpriteAnimators.Add(new SpriteAnimator(spriteAnimationCnfg, 10.0f));
                }
            }
            return _explosionsSpriteAnimators;
        }

    }
}
