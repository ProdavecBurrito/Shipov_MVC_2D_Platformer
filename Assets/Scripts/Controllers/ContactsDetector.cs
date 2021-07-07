using UnityEngine;

namespace Shipov_Platformer_MVC
{
    public class ContactsDetector : IUpdate
    {
        private const float _collisionThresh = 0.5f;
        private const int CONTACTS = 10;

        private ContactPoint2D[] _contacts = new ContactPoint2D[CONTACTS];
        private readonly Collider2D _collider2D;

        private int _contactsCount = 0;

        public bool IsGrounded { get; private set; }
        public bool HasLeftContacts { get; private set; }
        public bool HasRightContacts { get; private set; }

        public ContactsDetector(Collider2D collider2D)
        {
            _collider2D = collider2D;
        }

        public void CancelGrounded()
        {
            IsGrounded = false;
        }

        public void UpdateTick()
        {
            IsGrounded = false;
            HasLeftContacts = false;
            HasRightContacts = false;

            _contactsCount = _collider2D.GetContacts(_contacts);

            for (int i = 0; i < _contactsCount; i++)
            {
                var normal = _contacts[i].normal;
                var rigidBody = _contacts[i].rigidbody;

                if (normal.y > _collisionThresh)
                {
                    IsGrounded = true;
                }

                if (normal.x > _collisionThresh && rigidBody == null)
                {
                    HasLeftContacts = true;
                }

                if (normal.x < -_collisionThresh && rigidBody == null)
                {
                    HasRightContacts = true;
                }
            }
        }

    }
}
