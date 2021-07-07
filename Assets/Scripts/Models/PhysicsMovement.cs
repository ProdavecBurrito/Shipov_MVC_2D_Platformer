using UnityEngine;

namespace Shipov_Platformer_MVC
{
    public class PhysicsMovement : IMovement
    {
        private const int MAX_JUMPS = 2;

        private Rigidbody2D _rigidbody;
        private SpriteAnimator _spriteAnimator;
        private GroundChecker _groundChecker;
        private Vector3 _leftSide;
        private Vector3 _rightSide;
        private bool _isJumping;
        private bool _isWalk;
        private int _currentJumps;

        public PhysicsMovement(Rigidbody2D rigidbody, SpriteAnimator spriteAnimator)
        {
            _leftSide = new Vector3(-1, 1, 1);
            _rightSide = new Vector3(1, 1, 1);

            _rigidbody = rigidbody;
            _spriteAnimator = spriteAnimator;
            _groundChecker = rigidbody.transform.Find("GroundChecker").GetComponent<GroundChecker>();
        }

        public void UpdateMovement(float x, float currentSpeed, bool isJump, float jumpForce)
        {
            Move(x, currentSpeed);
            Jump(isJump, jumpForce);
            ChangeAnimation();
            CheckGrounded();
        }

        private void Move(float x, float currentSpeed)
        {
            if (x > 0 || x < 0)
            {
                _isWalk = true;
                if (x > 0)
                {
                    _rigidbody.transform.localScale = _rightSide;
                }

                else if (x < 0)
                {
                    _rigidbody.transform.localScale = _leftSide;
                }

                _rigidbody.AddForce(_rigidbody.transform.right * currentSpeed * x, ForceMode2D.Force);
            }
            else
            {
                _isWalk = false;
            }
        }

        private void Jump(bool isJump, float jumpForce)
        {
            if (isJump && _groundChecker.IsGrounded || isJump && _currentJumps != MAX_JUMPS)
            {
                _isJumping = true;
                _currentJumps++;
                _rigidbody.AddForce(Vector3.up * jumpForce, ForceMode2D.Impulse);
                _groundChecker.ChangeGrounded(false);
            }
        }

        private void ChangeAnimation()
        {
            if (_isJumping)
            {
                _spriteAnimator.StartAnimation(CharacterBehavior.character_jump, true);
            }
            else
            {
                if (_isWalk)
                {
                    _spriteAnimator.StartAnimation(CharacterBehavior.character_walk, true);
                }
                else
                {
                    _spriteAnimator.StartAnimation(CharacterBehavior.character_idle, true);
                }
            }
        }

        private void CheckGrounded()
        {
            if (_groundChecker.IsGrounded && _isJumping)
            {
                _isJumping = false;
                _currentJumps = 0;
            }
        }
    }
}
