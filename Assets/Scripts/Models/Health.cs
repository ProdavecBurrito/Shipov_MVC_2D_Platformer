using System;
using UnityEngine;

namespace Shipov_Platformer_MVC
{
    public class Health
    {
        public const float INVULNERABILITY_TIME = 5.0f;

        public event Action Die = delegate () {};
        public event Action HealthsChange = delegate () {};

        public Timer timer;
        public int MaxHealth { get;}
        public int CharacteHealth { get; private set; }
        public bool CanChangeHealth => _canChargeHealth;

        private bool _canChargeHealth;

        public Health(int maxHealth)
        {
            timer = new Timer();
            _canChargeHealth = true;
            MaxHealth = maxHealth;
            CharacteHealth = maxHealth;
        }

        public void GetGamage(int damage)
        {
            if (CanChangeHealth)
            {
                Debug.Log(CharacteHealth);
                timer.Init(INVULNERABILITY_TIME);
                _canChargeHealth = false;
                HealthsChange?.Invoke();
                CharacteHealth -= damage;
                if (CharacteHealth <= 0)
                {
                    Die?.Invoke();
                }
            }
        }

        public void GetHealth(int healValue)
        {
            CharacteHealth += healValue;
        }

        public void IsCanChangeHealth(bool value)
        {
            _canChargeHealth = value;
        }
    }
}
