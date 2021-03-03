using System.Collections.Generic;
using UnityEngine;

namespace Shipov_Platformer_MVC
{
    public class Initializer
    {
        public ParalaxManager ParalaxManager { get; private set; }
        public InputController InputController { get; private set; }
        public PlayerView PlayerView { get; private set; }
        public SpriteAnimator SpriteAnimator { get; private set; }
        public CameraController CameraController { get; private set; }
        public CannonView CannonView { get; private set; }
        public CannonBurrel CannonBurrel { get; private set; }
        public CannonController CannonController { get; private set; }
        public BulletPool BulletPool { get; private set; }
        public ContactsDetector ContactsDetector { get; private set; }

        public IMovement PlayerModel { get; private set; }

        public Initializer(Transform camera, Transform backGround)
        {
            var configAnimation = Resources.Load<SpriteAnimationCnfg>("PlayerAnimations");
            PlayerView = new PlayerView(new Health(100));
            ContactsDetector = new ContactsDetector(PlayerView.CharacterCollider);
            SpriteAnimator = new SpriteAnimator(configAnimation, PlayerView.CharacterSpriteRenderer, 5.0f);
            PlayerModel = new PhysicsMovement(PlayerView.CharacterRigidbody, SpriteAnimator, ContactsDetector);
            InputController = new InputController(PlayerModel, PlayerView);

            CameraController = new CameraController(PlayerView.CharacterTransform, camera);

            CannonView = new CannonView();

            CannonBurrel = new CannonBurrel(CannonView, PlayerView.PlayerGameObject.transform, new BulletPool(new List<BulletView>(5), CannonView._fireStartPosition));

            CannonController = new CannonController(CannonBurrel, CannonView);

            ParalaxManager = new ParalaxManager(camera, backGround);
        }
    }
}
