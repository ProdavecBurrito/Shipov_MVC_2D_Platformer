using UnityEngine;

namespace Shipov_Platformer_MVC
{
    public interface IBullet
    {
        void Fire(Transform fireStartTransform, Vector3 velocity);
        void Fly();
    }
}