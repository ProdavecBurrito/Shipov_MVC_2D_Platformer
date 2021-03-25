using UnityEngine;

namespace Shipov_Platformer_MVC
{
    public class BulletView : LevelObjectView
    {
        private TrailRenderer _trail;

        private int _damage = 25;

        public bool IsVisible;

        private void Start()
        {
            IsVisible = false;
            _trail = GetComponent<TrailRenderer>();
            CharacterTransform = GetComponent<Transform>();
            CharacterRigidbody = GetComponent<Rigidbody2D>();
        }

        public void SetVisible(bool visible)
        {
            CharacterTransform.gameObject.SetActive(visible); // Насколько это дорогая операция?
            IsVisible = visible;
            if (_trail)
            {
                _trail.enabled = visible;
            }
            if (_trail)
            {
                _trail.Clear();
            }
            CharacterSpriteRenderer.enabled = visible;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
                var player = collision.GetComponent<PlayerView>();
                player.Health.GetGamage(_damage);
                SetVisible(false);
                Debug.Log(player.Health.CharacteHealth);
            }
        }
    }
}