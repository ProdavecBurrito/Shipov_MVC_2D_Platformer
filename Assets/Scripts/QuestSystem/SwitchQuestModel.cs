using UnityEngine;

namespace Shipov_QuestSystem
{
    public class SwitchQuestModel : IQuestModel
    {
        private const string TargetTag = "Player";

        public bool TryComplete(GameObject activator)
        {
            return activator.CompareTag(TargetTag);
        }
    }
}
