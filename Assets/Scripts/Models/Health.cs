using System;

namespace Shipov_Platformer_MVC
{
    public class Health
    {
        public event Action Die = delegate() { };

        public int MaxHealth { get;}
        public int CharacteHealth { get; private set; }

        public Health(int maxHealth)
        {
            MaxHealth = maxHealth;
            CharacteHealth = maxHealth;
        }

        public void GetGamage(int damage)
        {
            CharacteHealth -= damage;
            if (CharacteHealth <= 0)
            {
                Die?.Invoke();
            }
        }

        public void GetHealth(int healValue)
        {
            CharacteHealth += healValue;
        }
    }
}
