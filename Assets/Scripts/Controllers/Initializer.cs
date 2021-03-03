using System.Collections.Generic;
using UnityEngine;

namespace Shipov_Platformer_MVC
{
    public class Initializer
    {
        public ParalaxManager ParalaxManager { get; private set; }
        public InputController InputController { get; private set; }
        public PlayerView PlayerView { get; private set; }
        public SpriteAnimator PlayerSpriteAnimator { get; private set; }
        public SpriteAnimator CoinsSpriteAnimator { get; private set; }
        public CameraController CameraController { get; private set; }
        public CannonView CannonView { get; private set; }
        public CannonBurrel CannonBurrel { get; private set; }
        public CannonController CannonController { get; private set; }
        public ContactsDetector ContactsDetector { get; private set; }
        public CoinManager CoinManager { get; private set; }

        public IMovement PlayerModel { get; private set; }

        public Initializer(Transform camera, Transform backGround)
        {
            var configPlayerAnimation = Resources.Load<SpriteAnimationCnfg>("PlayerAnimations");
            var configCoinsAnimation = Resources.Load<SpriteAnimationCnfg>("CoinsAnimations");

            PlayerView = new PlayerView(new Health(100), 35.0f);
            ContactsDetector = new ContactsDetector(PlayerView.CharacterCollider);
            PlayerSpriteAnimator = new SpriteAnimator(configPlayerAnimation, 5.0f);
            PlayerModel = new PhysicsMovement(PlayerView.CharacterRigidbody, PlayerSpriteAnimator, ContactsDetector, PlayerView.CharacterSpriteRenderer);
            InputController = new InputController(PlayerModel, PlayerView);

            CoinsSpriteAnimator = new SpriteAnimator(configCoinsAnimation, 10.0f);
            CoinManager = new CoinManager(PlayerView, new List<LevelObjectView>(), CoinsSpriteAnimator);

            CameraController = new CameraController(PlayerView.CharacterTransform, camera);

            CannonView = new CannonView();

            CannonBurrel = new CannonBurrel(CannonView, PlayerView.PlayerGameObject.transform, new BulletPool(new List<BulletView>(5), new PhysicBullet(new BulletView()), CannonView._cannonBarrel));

            CannonController = new CannonController(CannonBurrel, CannonView);

            ParalaxManager = new ParalaxManager(camera, backGround);
        }
    }
}
