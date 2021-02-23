using UnityEngine;

namespace Shipov_Platformer_MVC
{
    public class Health
    {
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
        }

        public void GetHealth(int healValue)
        {
            CharacteHealth += healValue;
        }
    }
}
