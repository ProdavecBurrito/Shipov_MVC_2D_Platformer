using UnityEngine;

namespace Shipov_Platformer_MVC
{
    public class CannonController : IUpdate
    {
        private CannonBurrel _cannonBurrel;
        private CannonView _cannonView;

        public CannonController(CannonBurrel cannonBurrel, CannonView cannonView)
        {
            _cannonBurrel = cannonBurrel;
            _cannonView = cannonView;
        }

        public void UpdateTick()
        {
            if (_cannonBurrel.IsFoundTarget())
            {
                _cannonBurrel.FollowTarget();
                //_cannonBurrel.Attack();
            }
            else
            {
                _cannonBurrel.StopAttack();
            }
        }
    }
}
