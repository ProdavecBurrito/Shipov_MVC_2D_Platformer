using System;
using UnityEngine;

namespace Shipov_Platformer_MVC
{
    public class BulletView : LevelObjectView
    {
        public event Action<Vector3> Explosion = delegate (Vector3 vector) { };

        private TrailRenderer _trail;

        private int _damage = 25;

        public bool IsVisible;

        private void Awake()
        {
            _trail = GetComponent<TrailRenderer>();
            CharacterTransform = GetComponent<Transform>();
            CharacterRigidbody = GetComponent<Rigidbody2D>();
            CharacterSpriteRenderer = GetComponent<SpriteRenderer>();
            SetVisible(false);
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
                Execute();
            }
        }

        public void Execute()
        {
            Explosion?.Invoke(transform.position);
        }
    }
}