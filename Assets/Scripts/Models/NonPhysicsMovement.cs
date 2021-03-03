using UnityEngine;

namespace Shipov_Platformer_MVC
{
    public class NonPhysicsMovement : IMovement
    {
        private const int MAX_JUMPS = 2;

        private Transform _playerTransform;
        private SpriteAnimator _spriteAnimator;
        private GroundChecker _groundChecker;

        private Vector3 _leftSide;
        private Vector3 _rightSide;

        private bool _isJumping;
        private bool _isWalk;
        private int _currentJumps;
        private float _yVelocity = 0;
        private float _accelerationOfGravity = -9.82f;

        public NonPhysicsMovement(Transform playerTransform, SpriteAnimator spriteAnimator, GroundChecker groundChecker)
        {
            _leftSide = new Vector3(-1, 1, 1);
            _rightSide = new Vector3(1, 1, 1);

            _playerTransform = playerTransform;
            _spriteAnimator = spriteAnimator;
            _groundChecker = groundChecker;
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
                    _playerTransform.transform.localScale = _rightSide;
                }

                else if (x < 0)
                {
                    _playerTransform.transform.localScale = _leftSide;
                }

                _playerTransform.Translate(x * currentSpeed * Time.deltaTime, 0.0f, 0.0f);
            }
            else
            {
                _isWalk = false;
            }
        }

        private void Jump(bool isJump, float jumpForce)
        {
            if (isJump && _groundChecker.IsGrounded && _yVelocity == 0 || isJump && _currentJumps != MAX_JUMPS)
            {
                _yVelocity = jumpForce * 2;
                _isJumping = true;
                _currentJumps++;
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
                _yVelocity = 0;
            }
            else if (!_groundChecker.IsGrounded && _isJumping)
            {
                _yVelocity += _accelerationOfGravity * Time.deltaTime;
                _playerTransform.position += Vector3.up * (Time.deltaTime * _yVelocity);
            }
        }
        
    }
}
