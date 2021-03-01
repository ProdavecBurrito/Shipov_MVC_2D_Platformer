﻿using UnityEngine;

namespace Shipov_Platformer_MVC
{
    public class BulletView : LevelObjectView
    {
        private TrailRenderer _trail;

        public GameObject BulletGameObject;
        public GroundChecker GroundChecker;

        public BulletView(IFactory factory)
        {
            BulletGameObject = factory.Create("CannonBullet");
            CharacterSpriteRenderer = BulletGameObject.GetComponent<SpriteRenderer>();
            _trail = BulletGameObject.GetComponent<TrailRenderer>();
            GroundChecker = BulletGameObject.transform.Find("GroundChecker").GetComponent<GroundChecker>();
        }

        public void SetVisible(bool visible)
        {
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