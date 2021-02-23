using UnityEngine;

namespace Shipov_Platformer_MVC
{
    public class PlayerModel
    {
        private Rigidbody2D _rigidbody;

        public PlayerModel(Rigidbody2D rigidbody)
        {
            _rigidbody = rigidbody;
        }

        public void Move(float x, float y, float z, float CurrentSpeed)
        {
            _rigidbody.AddForce(new Vector3(x, y, z) * CurrentSpeed * Time.deltaTime);
        }

        public void Jump(float jumpForce)
        {
            _rigidbody.AddForce(Vector3.up * jumpForce, ForceMode2D.Impulse);
        }
    }
}
