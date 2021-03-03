using UnityEngine;

namespace Shipov_Platformer_MVC
{
    public class BulletView : LevelObjectView
    {
        private TrailRenderer _trail;

        public GameObject BulletGameObject;
        public GroundChecker GroundChecker;

        public bool IsVisible;

        public BulletView()
        {
            BulletGameObject = LoadingGOFactory.Create("CannonBullet");
            CharacterSpriteRenderer = BulletGameObject.GetComponent<SpriteRenderer>();
            _trail = BulletGameObject.GetComponent<TrailRenderer>();
            GroundChecker = BulletGameObject.transform.Find("GroundChecker").GetComponent<GroundChecker>();
        }

        public void SetVisible(bool visible)
        {
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