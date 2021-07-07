using UnityEngine;

namespace Shipov_Platformer_MVC
{
    public class PlayerView : LevelObjectView
    {
        public Health Health;

        public MeshRenderer ShieldObject;
        public float Speed;
        public float JumpForce = 5.0f;
        public bool IsVisible;

        public void Awake()
        {
            IsVisible = false;
            CharacterTransform = GetComponent<Transform>();
            CharacterRigidbody = GetComponent<Rigidbody2D>();
            CharacterSpriteRenderer = GetComponent<SpriteRenderer>();
            CharacterCollider = GetComponent<Collider2D>();
            Health = new Health(100);
            ShieldObject = GetComponentInChildren<MeshRenderer>(true);
            Health.timer.StartCountDown += ShieldOn;
            Health.timer.EndCountDown += ShieldOn;
        }

        public void ShieldOn()
        {
            if (!IsVisible)
            {
                ShieldObject.enabled = true;
                IsVisible = true;
            }
            else
            {
                ShieldObject.enabled = false;
                IsVisible = false;
            }
        }
    }
}
