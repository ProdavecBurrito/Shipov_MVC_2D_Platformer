using UnityEngine;

namespace Shipov_Platformer_MVC
{
    public class CannonView
    {
        public const float MAX_MINUS_ANGLE = -90.0f;
        public const float MAX_PLUS_ANGLE = 90.0f;

        public Transform _cannonBarrel;
        public GameObject _cannonObject;

        public CannonView(IFactory factory)
        {
            _cannonObject = factory.Create("Cannon");
            _cannonBarrel = _cannonObject.GetComponentInChildren<Transform>().GetChild(0);
        }
    }
}
