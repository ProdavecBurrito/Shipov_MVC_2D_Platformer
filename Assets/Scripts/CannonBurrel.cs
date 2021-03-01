using UnityEngine;
using UnityEditor;

namespace Shipov_Platformer_MVC
{
    public class CannonBurrel
    {
        private const float MAX_SEARCH = 20.0f;

        private Transform _muzzleTransform;
        private Transform _targetTransform;
        private Transform _fireStartPosition;
        private Vector3 _startRotationPos;
        private LayerMask _layerMask;

        public Transform GetTarget => _targetTransform;

        public CannonBurrel(Transform muzzleTransform, Transform targetTransform)
        {
            _layerMask = LayerMask.GetMask("Player");
            _muzzleTransform = muzzleTransform;
            _targetTransform = targetTransform;
            _startRotationPos = Vector3.zero;
            _fireStartPosition = _muzzleTransform.Find("FireStartPos");
        }

        public bool IsFoundTarget()
        {
            return Physics2D.Raycast(_fireStartPosition.position, _fireStartPosition.TransformDirection(Vector2.up), MAX_SEARCH, _layerMask);
        }

        public void FollowTarget(Transform targetTransform)
        {
            var dir = _targetTransform.position - _muzzleTransform.position;
            var angle = Vector3.Angle(Vector3.up, dir);
            var axis = Vector3.Cross(Vector3.up, dir);
            _muzzleTransform.rotation = Quaternion.AngleAxis(angle, axis);
        }

        public void ChangeAngle(float angle)
        {
            _muzzleTransform.rotation = Quaternion.Euler(0, 0, angle);
        }

        public void Attack()
        {

        }

        public void ReloadAttack()
        {

        }

        protected void StopAttack()
        {
            _targetTransform = null;
        }


    }
}
