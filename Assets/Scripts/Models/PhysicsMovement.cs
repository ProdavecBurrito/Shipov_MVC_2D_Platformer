using UnityEngine;

namespace Shipov_Platformer_MVC
{
    public class PhysicsMovement : IMovement
    {
        private const int MAX_JUMPS = 2;
        private const float JUMP_TIME = 0.05f;
        private const float MAX_SPEED = 6.0f;
        private const float REDUCE_VELOSITY_VALUE = 0.5f;
        private float _currentJumpTime;

        private Rigidbody2D _characterRigidbody;
        private SpriteAnimator _spriteAnimator;
        private ContactsDetector _contactsDetector;
        private SpriteRenderer _spriteRenderer;

        private Vector2 _characterVelosity;
        private Vector3 _leftSide;
        private Vector3 _rightSide;

        private bool _isJumping;
        private bool _isWalk;
        private int _currentJumps;

        public PhysicsMovement(Rigidbody2D rigidbody, SpriteAnimator spriteAnimator, ContactsDetector contactsDetector, SpriteRenderer spriteRenderer)
        {
            _leftSide = new Vector3(-1, 1, 1);
            _rightSide = new Vector3(1, 1, 1);

            _characterRigidbody = rigidbody;
            _spriteAnimator = spriteAnimator;
            _contactsDetector = contactsDetector;
            _spriteRenderer = spriteRenderer;
        }

        public void UpdateMovement(float x, float currentSpeed, bool isJump, float jumpForce)
        {
            _contactsDetector.UpdateTick();
            CheckGrounded();
            Move(x, currentSpeed);
            Jump(isJump, jumpForce);
            ChangeAnimation();
        }

        private void Move(float x, float currentSpeed)
        {
            if (x > 0 || x < 0)
            {
                _isWalk = true;
                if (x > 0)
                {
                    _characterRigidbody.transform.localScale = _rightSide;
                }
                else if (x < 0)
                {
                    _characterRigidbody.transform.localScale = _leftSide;
                }

                _characterRigidbody.AddForce((_characterRigidbody.transform.right * x) * currentSpeed * Time.deltaTime, ForceMode2D.Force);
                CheckMaxValosity();
            }
            else
            {
                _isWalk = false;
            }
        }

        private void CheckMaxValosity()
        {
            _characterVelosity = _characterRigidbody.velocity;
            if (_characterRigidbody.velocity.x > MAX_SPEED)
            {
                _characterVelosity.x -= REDUCE_VELOSITY_VALUE;
            }
            else if (_characterRigidbody.velocity.x < -MAX_SPEED)
            {
                _characterVelosity.x += REDUCE_VELOSITY_VALUE;
            }
            _characterRigidbody.velocity = _characterVelosity;
        }

        private void Jump(bool isJump, float jumpForce)
        {
            if (isJump && _contactsDetector.IsGrounded || isJump && _currentJumps != MAX_JUMPS)
            {
                _isJumping = true;
                _currentJumps++;
                _characterRigidbody.AddForce(Vector3.up * jumpForce, ForceMode2D.Impulse);
                _contactsDetector.CancelGrounded();
            }
        }

        private void ChangeAnimation()
        {
            if (_isJumping)
            {
                _spriteAnimator.StartAnimation(_spriteRenderer, CharacterBehavior.character_jump, true);
            }
            else
            {
                if (_isWalk)
                {
                    _spriteAnimator.StartAnimation(_spriteRenderer, CharacterBehavior.character_walk, true);
                }
                else
                {
                    _spriteAnimator.StartAnimation(_spriteRenderer, CharacterBehavior.character_idle, true);
                }
            }
        }

        private void CheckGrounded()
        {
            if (_contactsDetector.IsGrounded && _isJumping && CanLand())
            {
                _isJumping = false;
                _currentJumps = 0;
            }
        }

        public bool CanLand() // Мне кажется, что это кастыль
        {
            if (_isJumping && _currentJumpTime < JUMP_TIME)
            {
                _currentJumpTime += Time.deltaTime;
                return false;
            }
            else
            {
                _currentJumpTime = 0;
                return true;
            }
        }
    }
}
