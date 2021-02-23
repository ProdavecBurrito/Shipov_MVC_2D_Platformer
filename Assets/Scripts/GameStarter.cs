using System.Collections.Generic;
using UnityEngine;

namespace Shipov_Platformer_MVC
{
    public class GameStarter : MonoBehaviour
    {
        [SerializeField] private Camera _mainCamera;
        [SerializeField] private Transform _backGround;
        [SerializeField] private LevelObjectView _levelObject;

        private UpdatingObjects _updatingObjects;
        private Initializer _initializer;
        private SpriteAnimator _spriteAnimator;

        void Awake()
        {
            var configAnimation = Resources.Load<SpriteAnimationCnfg>("PlayerAnimations");
            _updatingObjects = new UpdatingObjects();
            _initializer = new Initializer(_mainCamera.transform, _backGround);
            _spriteAnimator = new SpriteAnimator(configAnimation);

            _updatingObjects.AddUpdatingObject(_initializer.ParalaxManager);
            _updatingObjects.AddUpdatingObject(_spriteAnimator);
            _updatingObjects.AddUpdatingObject(_initializer.InputController);

            _spriteAnimator.StartAnimation(_levelObject.CharacterSpriteRenderer, CharacterBehavior.character_walk, true, 6);
        }

        void Update()
        {
            for (int i = 0; i < _updatingObjects.Count; i++)
            {
                _updatingObjects[i].UpdateTick();
            }
        }
    }
}
