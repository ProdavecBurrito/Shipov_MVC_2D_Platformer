using System.Collections.Generic;
using UnityEngine;
using System;

namespace Shipov_Platformer_MVC
{
    public class ProtectedZone
    {
        private readonly List<IProtector> _protectors;
        private readonly LevelTrigger _view;

        public ProtectedZone(LevelTrigger view, List<IProtector> protectors)
        {
            _view = view != null ? view : throw new ArgumentNullException(nameof(view));
            _protectors = protectors != null ? protectors : throw new ArgumentNullException(nameof(protectors)); ;
        }

        public void Init()
        {
            _view.TriggerEnter += OnContact;
            _view.TriggerExit += OnExit;
        }

        public void Deinit()
        {
            _view.TriggerEnter -= OnContact;
            _view.TriggerExit -= OnExit;
        }

        private void OnContact(object sender, GameObject gameObject)
        {
            foreach (var protector in _protectors)
            {
                protector.StartProtection(gameObject);
            }
        }

        private void OnExit(object sender, GameObject gameObject)
        {
            foreach (var protector in _protectors)
            {
                protector.FinishProtection(gameObject);
            }
        }
    }
}
