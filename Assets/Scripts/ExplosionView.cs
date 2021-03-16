using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shipov_Platformer_MVC
{
    public class ExplosionView : LevelObjectView
    {
        public SpriteAnimator _spriteAnimator;

        private void Awake()
        {
            CharacterTransform = GetComponent<Transform>();
            CharacterSpriteRenderer = GetComponent<SpriteRenderer>();
        }

        public void Expload(Vector3 vector)
        {
            CharacterTransform.position = vector;
            _spriteAnimator.StartAnimation(CharacterSpriteRenderer, CharacterBehavior.character_walk, false);
        }
    }
}
