using UnityEngine;

namespace Shipov_Platformer_MVC
{
    public class BulletView : LevelObjectView
    {
        private TrailRenderer _trail;

        public GameObject BulletGameObject;
        public GroundChecker GroundChecker;
        public Rigidbody2D BulletRigidBody;

        public bool IsVisible;

        public BulletView()
        {
            IsVisible = false;
            BulletGameObject = LoadingGOFactory.Create("CannonBullet");
            CharacterTransform = BulletGameObject.transform;
            CharacterSpriteRenderer = BulletGameObject.GetComponent<SpriteRenderer>();
            _trail = BulletGameObject.GetComponent<TrailRenderer>();
            BulletRigidBody = BulletGameObject.GetComponent<Rigidbody2D>();
        }

        public void SetVisible(bool visible)
        {
            CharacterTransform.gameObject.SetActive(visible); // Насколько это дорогая операция?
            IsVisible = visible;
            if (_trail)
            {
                _trail.enabled = visible;
            }
            if (_trail)
            {
                _trail.Clear();
            }
            CharacterSpriteRenderer.enabled = visible;
        }

    }
}