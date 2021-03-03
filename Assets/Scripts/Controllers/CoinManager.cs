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
        private GameObject _mainCoinsObject;

        public CoinManager(LevelObjectView characterView, List<LevelObjectView> coinViews, SpriteAnimator spriteAnimator)
        {
            _mainCoinsObject = LoadingGOFactory.Create("Coins");
            _characterView = characterView;
            _spriteAnimator = spriteAnimator;
            _coinViews = coinViews;
            _characterView.OnLevelObjectContact += OnLevelObjectContact;

            for(int i = 0; i < _mainCoinsObject.transform.childCount; i++) // Мне кажется, это тоже спорная штука
            {
                _coinViews.Add(new LevelObjectView());
                _coinViews[i].CharacterTransform = _mainCoinsObject.transform.GetChild(i).transform;
                _coinViews[i].CharacterSpriteRenderer = _mainCoinsObject.transform.GetChild(i).GetComponent<SpriteRenderer>();
            }

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
