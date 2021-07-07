using UnityEngine;

namespace Shipov_Platformer_MVC
{
    public class GroundChecker : MonoBehaviour
    {
        [SerializeField]  private bool _isGrounded;
        public bool IsGrounded => _isGrounded;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Ground"))
            {
                _isGrounded = true;
            }
        }

        public void ChangeGrounded(bool isGrounded)
        {
           _isGrounded = isGrounded;
        }
    }
}
