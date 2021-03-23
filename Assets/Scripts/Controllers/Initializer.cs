using LevelGenerator;
using UnityEngine;

namespace Shipov_Platformer_MVC
{
    public class Initializer
    {
        public ExplosionsInitializer ExplosionsPool { get; private set; }
        public References References { get; private set; }
        public ParalaxManager ParalaxManager { get; private set; }
        public InputController InputController { get; private set; }
        public PlayerView PlayerView { get; private set; }
        public LevelManager LevelManager { get; private set; }
        public SpriteAnimator PlayerSpriteAnimator { get; private set; }
        public SpriteAnimator CoinsSpriteAnimator { get; private set; }
        public CameraController CameraController { get; private set; }
        public CannonView CannonView { get; private set; }
        public CannonBurrel CannonBurrel { get; private set; }
        public CannonController CannonController { get; private set; }
        public ContactsDetector ContactsDetector { get; private set; }
        public CoinManager CoinManager { get; private set; }

        public IMovement PlayerMovement { get; private set; }

        public GeneratingLevelController GeneratingLevelController { get; private set; }

        public Initializer(Transform camera, Transform backGround)
        {

            var bulletType = "PhysicBullet";
            References = new References();
            var bulletViews = References.GetBulletViews;

            var configCannonBulletAnimation = Resources.Load<SpriteAnimationCnfg>("CannonBulletExplosion");
            var configPlayerAnimation = Resources.Load<SpriteAnimationCnfg>("PlayerAnimations");
            var configCoinsAnimation = Resources.Load<SpriteAnimationCnfg>("CoinsAnimations");
            var configBulletExplosions = Resources.Load<SpriteAnimationCnfg>("CannonBulletExplosion");
            PlayerView = References.GetPlayer;

            ContactsDetector = new ContactsDetector(PlayerView.CharacterCollider);
            PlayerSpriteAnimator = new SpriteAnimator(configPlayerAnimation, 5.0f);
            PlayerMovement = new PhysicsMovement(PlayerView.CharacterRigidbody, PlayerSpriteAnimator, ContactsDetector, PlayerView.CharacterSpriteRenderer);
            InputController = new InputController(PlayerMovement, PlayerView);

            LevelManager = new LevelManager(PlayerView, References.GetDeathTriggers, References.GetWindZones);

            CoinsSpriteAnimator = new SpriteAnimator(configCoinsAnimation, 10.0f);
            CoinManager = new CoinManager(PlayerView, References.GetCoins, CoinsSpriteAnimator);

            CameraController = new CameraController(PlayerView.transform, camera);

            CannonView = new CannonView();

            CannonBurrel = new CannonBurrel(CannonView, PlayerView.transform, new BulletPool(bulletViews, bulletType, CannonView._cannonBarrel));

            CannonController = new CannonController(CannonBurrel, CannonView);

            ParalaxManager = new ParalaxManager(camera, backGround);

            ExplosionsPool = new ExplosionsInitializer(References.GetCannonExplosions, References.GetBulletViews, References.GetExplosionAnimators(configBulletExplosions));

            GeneratingLevelController = new GeneratingLevelController(GameObject.FindObjectOfType<GeneratingLevelView>());
        }
    }
}
