using System.Collections.Generic;
using UnityEngine;

namespace Shipov_Platformer_MVC
{
    public class References
    {
        private PlayerView _playerView;
        private List<LevelObjectView> _coins;
        private List<BulletView> _bullets;
        private List<DeathTrigger> _deathTriggers;
        private List<WinTrigger> _winTriggers;

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
                    _bullets = new List<BulletView>(5);
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
    }
}
