using System;
using UnityEngine;

namespace Shipov_Platformer_MVC
{
    public class LevelObjectView
    {
        public Transform CharacterTransform;
        public Rigidbody2D CharacterRigidbody;
        public SpriteRenderer CharacterSpriteRenderer;
        public Collider2D CharacterCollider;
        public Collider2D TargetCollider;

        public Action<LevelObjectView> OnLevelObjectContact { get; set; }

        //void OnTriggerEnter2D(Collider2D collider)
        //{
        //    var levelObject = collider.gameObject.GetComponent<LevelObjectView>();
        //    OnLevelObjectContact?.Invoke(levelObject);
        //}
    }
}
