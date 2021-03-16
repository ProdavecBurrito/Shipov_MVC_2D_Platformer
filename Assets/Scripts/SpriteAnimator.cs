using System.Collections.Generic;
using UnityEngine;
using System;

namespace Shipov_Platformer_MVC
{
    public class SpriteAnimator : IUpdate, IDisposable
    {
        private float _speed;

        private SpriteAnimationCnfg _config;
        private Dictionary<SpriteRenderer, CharacterAnimation> _activeAnimations = new Dictionary<SpriteRenderer, CharacterAnimation>();

        public SpriteAnimator(SpriteAnimationCnfg config, float speed)
        {
            _config = config;
            _speed = speed;
        }

        public void UpdateTick()
        {
            foreach (var animation in _activeAnimations)
            {
                animation.Value.UpdateTick();
                animation.Key.sprite = animation.Value.Sprites[(int)animation.Value.Counter];
            }
        }

        public void StartAnimation(SpriteRenderer spriteRenderer, CharacterBehavior bahaviorAnimation, bool loop)
        {
            if (_activeAnimations.TryGetValue(spriteRenderer, out var animation))
            {
                animation.Loop = loop;
                animation.Speed = _speed;
                animation.Sleeps = false;

                if (animation.BahaviorAnimation != bahaviorAnimation)
                {
                    animation.BahaviorAnimation = bahaviorAnimation;
                    animation.Sprites = _config.SpriteSet.Find(sequence => sequence.CharacterBehavior == bahaviorAnimation).Sprites;
                    animation.Counter = 0;
                }
            }
            else
            {
                _activeAnimations.Add(spriteRenderer, new CharacterAnimation()
                {
                    BahaviorAnimation = bahaviorAnimation,
                    Sprites = _config.SpriteSet.Find(sequence => sequence.CharacterBehavior == bahaviorAnimation).Sprites,
                    Loop = loop,
                    Speed = _speed
                });
            }
        }

        public void StopAnimation(SpriteRenderer sprite)
        {
            if (_activeAnimations.ContainsKey(sprite))
            {
                _activeAnimations.Remove(sprite);
            }
        }

        public void Dispose()
        {
            _activeAnimations.Clear();
        }
    }
}
