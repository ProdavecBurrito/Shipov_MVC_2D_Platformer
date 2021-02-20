using System.Collections.Generic;
using UnityEngine;

namespace Shipov_Platformer_MVC
{
    public class GameStarter : MonoBehaviour
    {
        [SerializeField] private Camera _mainCamera;
        [SerializeField] private Transform _backGround;

        private UpdatingObjects _updatingObjects;
        private Initializer _initializer;

        void Awake()
        {
            _updatingObjects = new UpdatingObjects();
            _initializer = new Initializer(_mainCamera.transform, _backGround);

            _updatingObjects.AddUpdatingObject(_initializer.ParalaxManager);
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
