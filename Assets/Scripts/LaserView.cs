using UnityEngine;

namespace Shipov_Platformer_MVC
{
    public class LaserView : LevelObjectView
    {
        private int _damage = 10;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
                var player = collision.GetComponent<PlayerView>();
                player.Health.GetGamage(_damage);
            }
        }
    }
}
