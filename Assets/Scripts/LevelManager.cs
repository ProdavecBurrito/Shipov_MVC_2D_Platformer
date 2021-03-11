using UnityEngine;
using System;
using System.Collections.Generic;

namespace Shipov_Platformer_MVC
{
    public class LevelManager : IDisposable
    {
        private Vector3 _startPosition;
        private PlayerView _characterView;
        private List<DeathTrigger> _deathZones;
        private List<WinTrigger> _winZones;

        public LevelManager(PlayerView characterView, List<DeathTrigger> deathZones, List<WinTrigger> winZones)
        {
            _startPosition = characterView.CharacterTransform.position;
            characterView.OnLevelObjectContact += OnLevelObjectContact;
            characterView.Health.Die += ReturnToStart;

            _characterView = characterView;
            _deathZones = deathZones;
            _winZones = winZones;
        }

        private void OnLevelObjectContact(LevelObjectView contactView)
        {
            if (_deathZones.Contains(contactView as DeathTrigger))
            {
                ReturnToStart();
            }
            
            if (_winZones.Contains(contactView as WinTrigger))
            {
                ReturnToStart();
            }
        }

        public void ReturnToStart()
        {
            _characterView.CharacterTransform.position = _startPosition;
        }

        public void Dispose()
        {
            _characterView.OnLevelObjectContact -= OnLevelObjectContact;
        }

    }
}
