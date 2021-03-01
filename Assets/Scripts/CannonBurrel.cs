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
        private BulletPool _bulletPool;

        public Transform FireStartPosition => _fireStartPosition;

        private Vector3 _startRotationPos;
        private LayerMask _layerMask;

        public Transform GetTarget => _targetTransform;

        public CannonBurrel(Transform muzzleTransform, Transform fireStartPos, Transform targetTransform, BulletPool bulletPool)
        {

            _fireStartPosition = fireStartPos;
            _bulletPool = bulletPool;
            _layerMask = LayerMask.GetMask("Player");
            _muzzleTransform = muzzleTransform;
            _targetTransform = targetTransform;
            _startRotationPos = new Vector3(0, 0, 0);
        }

        public bool IsFoundTarget()
        {
            return Physics2D.Raycast(_fireStartPosition.position, _fireStartPosition.TransformDirection(Vector2.up), MAX_SEARCH, _layerMask);
        }

        public void FollowTarget()
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
            _bulletPool.TryAttack();
        }

        public void ReloadAttack()
        {

        }

        public void StopAttack()
        {
            _muzzleTransform.localEulerAngles = _startRotationPos;
        }


    }
}
