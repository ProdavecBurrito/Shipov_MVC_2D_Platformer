using System;

namespace Shipov_Platformer_MVC
{
    public class Health
    {
        public const float INVULNERABILITY_TIME = 5.0f;

        public event Action Die = delegate () {};
        public event Action HealthsChange = delegate () {};

        public int MaxHealth { get;}
        public int CharacteHealth { get; private set; }
        public bool CanChangeHealth;

        public Health(int maxHealth)
        {
            CanChangeHealth = true;
            MaxHealth = maxHealth;
            CharacteHealth = maxHealth;
        }

        public void GetGamage(int damage)
        {
            if (CanChangeHealth)
            {
                CanChangeHealth = false;
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
    }
}
