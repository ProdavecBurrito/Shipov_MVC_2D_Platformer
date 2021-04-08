using Pathfinding;
using System;

namespace Shipov_Platformer_MVC
{
    public class AIPatrolPath : AIPath
    {

        public event EventHandler TargetReached;

        public override void OnTargetReached()
        {
            base.OnTargetReached();
            DispatchTargetReached();
        }

        protected virtual void DispatchTargetReached()
        {
            TargetReached?.Invoke(this, EventArgs.Empty);
        }
    }
}
