using UnityEngine;

namespace Shipov_Platformer_MVC
{
    public class Initializer
    {
        public ParalaxManager ParalaxManager { get; private set; }
        public InputController InputController { get; private set; }
        public PlayerView PlayerView { get; private set; }
        public IMovement PlayerModel { get; private set; }
        public SpriteAnimator SpriteAnimator { get; private set; }
        public CameraController CameraController { get; private set; }
        public IFactory Factory { get; private set; }
        public GroundChecker GroundChecker { get; private set;}
        public CannonView CannonView { get; private set; }
        public CannonBurrel CannonBurrel { get; private set; }
        public CannonController CannonController { get; private set; }

        public Initializer(Transform camera, Transform backGround)
        {
            var configAnimation = Resources.Load<SpriteAnimationCnfg>("PlayerAnimations");

            Factory = new LoadingGOFactory();

            PlayerView = new PlayerView(new Health(100), Factory);
            GroundChecker = GameObject.FindObjectOfType<GroundChecker>();
            SpriteAnimator = new SpriteAnimator(configAnimation, PlayerView.CharacterSpriteRenderer, 5.0f);
            PlayerModel = new PhysicsMovement(PlayerView.CharacterRigidbody, SpriteAnimator, GroundChecker);
            InputController = new InputController(PlayerModel, PlayerView);

            CameraController = new CameraController(PlayerView.CharacterTransform, camera);

            CannonView = new CannonView(Factory);
            CannonBurrel = new CannonBurrel(CannonView._cannonBarrel, PlayerView.PlayerGameObject.transform);
            CannonController = new CannonController(CannonBurrel, CannonView);

            ParalaxManager = new ParalaxManager(camera, backGround);
        }
    }
}
