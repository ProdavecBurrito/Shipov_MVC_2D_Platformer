using UnityEngine;

namespace Shipov_Platformer_MVC
{
    public class Initializer
    {
        public ParalaxManager ParalaxManager { get; private set; }
        public InputController InputController { get; private set; }
        public PlayerView PlayerView { get; private set; }
        public PlayerModel PlayerModel { get; private set; }
        public IFactory Factory { get; private set; }

        public Initializer(Transform camera, Transform backGround)
        {
            Factory = new LoadingGOFactory();
            PlayerView = new PlayerView(new Health(100), Factory);
            PlayerModel = new PlayerModel(PlayerView.CharacterRigidbody);
            InputController = new InputController(PlayerModel, PlayerView);

            ParalaxManager = new ParalaxManager(camera, backGround);
        }
    }
}
