using UnityEngine;

namespace Shipov_Platformer_MVC
{
    public class PlayerView : LevelObjectView
    {
        public Health Health;

        public float Speed;
        public float JumpForce = 5.0f;

        public void Awake()
        {
            CharacterTransform = GetComponent<Transform>();
            CharacterRigidbody = GetComponent<Rigidbody2D>();
            CharacterSpriteRenderer = GetComponent<SpriteRenderer>();
            CharacterCollider = GetComponent<Collider2D>();
            Health = new Health(100);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            var levelObject = collision.gameObject.GetComponent<LevelObjectView>();
            OnLevelObjectContact?.Invoke(levelObject);
        }
    }
}
