using System.Collections.Generic;
using UnityEngine;
using System;

namespace Shipov_Platformer_MVC
{
    [CreateAssetMenu(fileName = "SpriteAnimationsConfig", menuName = "Configs / SpriteAnimationsConfig", order = 1)]
    public class SpriteAnimationCnfg : ScriptableObject
    {
        [Serializable]
        public class SpriteSets
        {
            public CharacterBehavior CharacterBehavior;
            public List<Sprite> Sprites = new List<Sprite>();
        }

        public List<SpriteSets> SpriteSet = new List<SpriteSets>();
    }
}
