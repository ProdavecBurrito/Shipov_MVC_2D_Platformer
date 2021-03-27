using UnityEngine;

namespace Shipov_QuestSystem
{
    public class TriggerQuestView : BaseQuestObjectView
    {

        public Collider2D _compliteQuestTrigger;

        private void Awake()
        {
            _compliteQuestTrigger = CharacterCollider;
        }

        public override void ProcessActivate()
        {
            _compliteQuestTrigger.enabled = false;
        }

        public override void ProcessComplete()
        {
            _compliteQuestTrigger.enabled = true;
        }
    }
}
