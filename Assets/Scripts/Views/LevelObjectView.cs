using System;
using UnityEngine;

namespace Shipov_Platformer_MVC
{
    public class LevelObjectView : MonoBehaviour
    {
        public Transform CharacterTransform;
        public Rigidbody2D CharacterRigidbody;
        public SpriteRenderer CharacterSpriteRenderer;
        public Collider2D CharacterCollider;

        private void Awake()
        {
            CharacterTransform = GetComponent<Transform>();
            CharacterRigidbody = GetComponent<Rigidbody2D>();
            CharacterSpriteRenderer = GetComponent<SpriteRenderer>();
            CharacterCollider = GetComponent<Collider2D>();
        }

        public Action<LevelObjectView> OnLevelObjectContact { get; set; }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            var levelObject = collision.gameObject.GetComponent<LevelObjectView>();
            OnLevelObjectContact?.Invoke(levelObject);
        }
    }
}
