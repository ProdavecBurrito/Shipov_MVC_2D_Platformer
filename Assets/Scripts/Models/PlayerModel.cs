using UnityEngine;

namespace Shipov_Platformer_MVC
{
    public class PlayerModel
    {
        private Rigidbody2D _rigidbody;
        private SpriteAnimator _spriteAnimator;

        public PlayerModel(Rigidbody2D rigidbody, SpriteAnimator spriteAnimator)
        {
            _rigidbody = rigidbody;
            _spriteAnimator = spriteAnimator;
        }

        public void Move(float x, float y, float CurrentSpeed)
        {
            if (x > 0 || x < 0)
            {
                _rigidbody.AddForce(new Vector2(x, y) * CurrentSpeed, ForceMode2D.Force);
                _spriteAnimator.StartAnimation(CharacterBehavior.character_walk, true);
            }
            else
            {
                _spriteAnimator.StartAnimation(CharacterBehavior.character_idle, true);
            }
        }

        public void Jump(float jumpForce)
        {
            _rigidbody.AddForce(Vector3.up * jumpForce, ForceMode2D.Impulse);
            _spriteAnimator.StartAnimation(CharacterBehavior.character_jump, true);
        }
    }
}
