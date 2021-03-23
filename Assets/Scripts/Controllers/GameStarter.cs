using System.Collections.Generic;
using UnityEngine;

namespace Shipov_Platformer_MVC
{
    public class GameStarter : MonoBehaviour
    {
        [SerializeField] private Camera _mainCamera;
        [SerializeField] private Transform _backGround;

        private LevelObjectView[] levelObjectViews;
        private List<LevelObjectView> levelObjects;
        private UpdatingObjects<IUpdate> _updatingObjects;
        private UpdatingObjects<IFixedUpdate> _fixedUpdatingObjects;
        private Initializer _initializer;

        void Awake()
        {

            _updatingObjects = new UpdatingObjects<IUpdate>();
            _fixedUpdatingObjects = new UpdatingObjects<IFixedUpdate>();
            _initializer = new Initializer(_mainCamera.transform, _backGround);

            _updatingObjects.AddUpdatingObject(_initializer.ParalaxManager);
            _updatingObjects.AddUpdatingObject(_initializer.InputController);
            _updatingObjects.AddUpdatingObject(_initializer.PlayerSpriteAnimator);
            _updatingObjects.AddUpdatingObject(_initializer.CannonController);
            _updatingObjects.AddUpdatingObject(_initializer.CoinsSpriteAnimator);

            foreach (var item in _initializer.References.GetExposionsSpriteAnimators)
            {
                _updatingObjects.AddUpdatingObject(item);
            }

            _fixedUpdatingObjects.AddUpdatingObject(_initializer.CameraController);

            _initializer.GeneratingLevelController.AwakeTick();
        }

        void Update()
        {
            for (int i = 0; i < _updatingObjects.Count; i++)
            {
                _updatingObjects[i].UpdateTick();
            }
        }

        private void FixedUpdate()
        {
            for (int i = 0; i < _fixedUpdatingObjects.Count; i++)
            {
                _fixedUpdatingObjects[i].FixedUpdateTick();
            }
        }
    }
}
