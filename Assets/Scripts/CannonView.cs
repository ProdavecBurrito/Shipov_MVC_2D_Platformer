using UnityEngine;

namespace Shipov_Platformer_MVC
{
    public class CannonView
    {
        public const float MAX_MINUS_ANGLE = -90.0f;
        public const float MAX_PLUS_ANGLE = 90.0f;

        public GameObject _cannonMainObject;
        public Transform _cannonBarrel;
        public Transform _fireStartPosition;

        public CannonView(IFactory factory)
        {
            _cannonMainObject = factory.Create("Cannon");
            _cannonBarrel = _cannonMainObject.GetComponentInChildren<Transform>().GetChild(0);
            _fireStartPosition = _cannonBarrel.GetChild(0);
        }
    }
}
