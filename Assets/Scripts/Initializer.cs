using UnityEngine;

namespace Shipov_Platformer_MVC
{
    public class Initializer
    {
        public ParalaxManager ParalaxManager { get; private set; }

        public Initializer(Transform camera, Transform backGround)
        {
            ParalaxManager = new ParalaxManager(camera, backGround);
        }
    }
}
