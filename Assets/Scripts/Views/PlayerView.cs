using UnityEngine;

namespace Shipov_Platformer_MVC
{
    public class PlayerView : LevelObjectView
    {
        public Health Health;
        public GameObject PlayerGameObject;

        public float Speed = 2.5f;
        public float JumpForce = 5.0f;

        public PlayerView(Health health, IFactory factory)
        {
            Health = health;
            PlayerGameObject = factory.Create("AstroMainChar");
            CharacterTransform = PlayerGameObject.transform;

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
    }
}
