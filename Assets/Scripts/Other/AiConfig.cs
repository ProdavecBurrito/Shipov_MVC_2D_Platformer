using System;
using UnityEngine;

namespace Shipov_Platformer_MVC
{
    [Serializable]
    public struct AIConfig
    {
        public float Speed;
        public float MinSqrDistanceToTarget;
        public Transform[] Waypoints;
    }
}

