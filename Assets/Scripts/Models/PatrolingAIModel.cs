using UnityEngine;

namespace Shipov_Platformer_MVC
{
    public class PatrolingAIModel
    {

        private readonly AIConfig _config;
        private Transform _target;
        private int _currentPointIndex;

        public PatrolingAIModel(AIConfig config)
        {
            _config = config;
            _target = GetNextWaypoint();
        }

        public Vector2 CalculateVelocity(Vector2 fromPosition)
        {
            var sqrDistance = Vector2.SqrMagnitude((Vector2)_target.position - fromPosition);
            if (sqrDistance <= _config.MinSqrDistanceToTarget)
            {
                _target = GetNextWaypoint();
            }

            var direction = ((Vector2)_target.position - fromPosition).normalized;
            return _config.Speed * direction;
        }

        private Transform GetNextWaypoint()
        {
            _currentPointIndex = (_currentPointIndex + 1) % _config.Waypoints.Length;
            return _config.Waypoints[_currentPointIndex];
        }
    }
}