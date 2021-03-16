using System.Collections.Generic;
using UnityEngine;
using System;

namespace Shipov_Platformer_MVC
{
    public class ExplosionsPool : IDisposable
    {
        private List<ExplosionView> _explosions;
        private List<SpriteAnimator> _spriteAnimators;
        private List<BulletView> _startPos;

        public ExplosionsPool(List<ExplosionView> explosions, List<BulletView> startPos, List<SpriteAnimator> spriteAnimators)
        {
            _explosions = explosions;
            _spriteAnimators = spriteAnimators;
            _startPos = startPos;

            for (int i = 0; i < startPos.Count; i++)
            {
                _explosions[i]._spriteAnimator = _spriteAnimators[i];
                startPos[i].Explosion += _explosions[i].Expload;
            }
        }

        public void Dispose()
        {
            for (int i = 0; i < _startPos.Count; i++)
            {
                _startPos[i].Explosion -= _explosions[i].Expload;
            }
        }
    }
}
