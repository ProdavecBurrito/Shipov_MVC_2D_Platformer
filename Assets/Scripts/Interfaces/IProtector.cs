using UnityEngine;

namespace Shipov_Platformer_MVC
{
    public interface IProtector
    {
        void StartProtection(GameObject invader);
        void FinishProtection(GameObject invader);
    }
}
