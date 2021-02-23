using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shipov_Platformer_MVC
{
    public class CharacterAnimation
    {
        public CharacterBehavior BahaviorAnimation;
        public List<Sprite> Sprites;

        public float Speed = 10;
        public float Counter = 0;
        public bool Loop = false;
        public bool Sleeps;

        public void UpdateTick()
        {
            if (!Sleeps)
            {
                Counter += Time.deltaTime * Speed;
                if (Loop)
                {
                    while (Counter > Sprites.Count)
                    {
                        Counter -= Sprites.Count;
                    }
                }
                else if (Counter > Sprites.Count)
                {
                    Counter = Sprites.Count - 1;
                    Sleeps = true;
                }
            }
        }
    }
}
