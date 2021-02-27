using UnityEngine;

namespace Shipov_Platformer_MVC
{
    public class NonPhysicsMovement /*: IMovement*/
    {
        private Transform _playerTransform;
        private SpriteAnimator _spriteAnimator;
        private Vector3 _leftSide;
        private Vector3 _rightSide;
        private float _yVelocity = 0;

        public NonPhysicsMovement(Transform playerTransform, SpriteAnimator spriteAnimator)
        {
            _leftSide = new Vector3(-1, 1, 1);
            _rightSide = new Vector3(1, 1, 1);

            _playerTransform = playerTransform;
            _spriteAnimator = spriteAnimator;
        }

        public void Move(float x, float speed)
        {
            if (x > 0 || x < 0)
            {
                if (x > 0)
                {
                    _playerTransform.localScale = _rightSide;
                }
                else if (x < 0)
                {
                    _playerTransform.localScale = _leftSide;
                }

                _playerTransform.Translate(x * speed * Time.deltaTime, 0.0f, 0.0f);
                _spriteAnimator.StartAnimation(CharacterBehavior.character_walk, true);
            }
            else
            {
                _spriteAnimator.StartAnimation(CharacterBehavior.character_idle, true);
            }
        }

        public void Jump(bool isJump ,float jumpForce)
        {
            if (isJump)
            {
                _playerTransform.position += Vector3.up * (jumpForce * Time.deltaTime);
                _spriteAnimator.StartAnimation(CharacterBehavior.character_jump, true);
            }
        }
    }
}
