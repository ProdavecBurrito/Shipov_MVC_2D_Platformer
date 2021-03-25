using System.Collections.Generic;
using UnityEngine;
using System;

namespace Shipov_Platformer_MVC
{
    public class CoinManager : IDisposable
    {
        private LevelObjectView _characterView;
        private SpriteAnimator _spriteAnimator;
        private List<LevelObjectView> _coinViews;

        public CoinManager(LevelObjectView characterView, List<LevelObjectView> coinViews, SpriteAnimator spriteAnimator)
        {
            _characterView = characterView;
            _spriteAnimator = spriteAnimator;
            _coinViews = coinViews;
            _characterView.OnLevelObjectContact += OnLevelObjectContact;

            foreach (var coinView in coinViews)
            {
                _spriteAnimator.StartAnimation(coinView.CharacterSpriteRenderer, CharacterBehavior.character_walk, true);
            }
        }

        private void OnLevelObjectContact(LevelObjectView contactView)
        {
            if (_coinViews.Contains(contactView))
            {
                _spriteAnimator.StopAnimation(contactView.CharacterSpriteRenderer);
                GameObject.Destroy(contactView.CharacterTransform.gameObject);
            }
        }

        public void Dispose()
        {
            _characterView.OnLevelObjectContact -= OnLevelObjectContact;
        }
    }
}
