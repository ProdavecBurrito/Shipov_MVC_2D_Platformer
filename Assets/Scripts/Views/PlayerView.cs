using UnityEngine;

namespace Shipov_Platformer_MVC
{
    public class PlayerView : LevelObjectView
    {
        public const float MAX_TIME = 5.0f;

        public Health Health;

        public float Speed;
        public float JumpForce = 5.0f;
        public Timer Timer;

        public void Awake()
        {
            CharacterTransform = GetComponent<Transform>();
            CharacterRigidbody = GetComponent<Rigidbody2D>();
            CharacterSpriteRenderer = GetComponent<SpriteRenderer>();
            CharacterCollider = GetComponent<Collider2D>();
            Health = new Health(100);
        }
    }
}
