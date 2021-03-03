using UnityEngine;

namespace Shipov_Platformer_MVC
{
    public class PlayerView : LevelObjectView
    {
        public Health Health;
        public GameObject PlayerGameObject;

        public LayerMask LayerMask = LayerMask.NameToLayer("Usable");

        public float Speed;
        public float JumpForce = 5.0f;

        public PlayerView(Health health, float speed)
        {
            Speed = speed;
            Health = health;
            PlayerGameObject = LoadingGOFactory.Create("AstroMainChar");
            CharacterTransform = PlayerGameObject.transform;
            CharacterCollider = PlayerGameObject.GetComponent<Collider2D>();

            if (PlayerGameObject.TryGetComponent<Rigidbody2D>(out Rigidbody2D rigidbody))
            {
                CharacterRigidbody = rigidbody;
            }
            else
            {
                CharacterRigidbody = PlayerGameObject.AddComponent(typeof(Rigidbody2D)) as Rigidbody2D;
            }

            if (PlayerGameObject.TryGetComponent<SpriteRenderer>(out SpriteRenderer spriteRenderer))
            {
                CharacterSpriteRenderer = spriteRenderer;
            }
            else
            {
                CharacterSpriteRenderer = PlayerGameObject.AddComponent(typeof(SpriteRenderer)) as SpriteRenderer;
            }
        }


        public void OnTriggerEnterRealization()
        {
            if (CharacterCollider is CircleCollider2D circleCollider2D)
            {
                TargetCollider = Physics2D.OverlapCircle(circleCollider2D.transform.position, circleCollider2D.radius, LayerMask.value);
                if (TargetCollider.)
            }

            if (TargetCollider.CompareTag("Usable"))
            {
                OnLevelObjectContact?.Invoke();
            }
        }
    }
    }
}
