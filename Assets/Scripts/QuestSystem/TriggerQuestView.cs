using UnityEngine;

namespace Shipov_QuestSystem
{
    public class TriggerQuestView : BaseQuestObjectView
    {

        public Collider2D _compliteQuestTrigger;

        private void Awake()
        {
            CharacterCollider = GetComponent<Collider2D>();
            _compliteQuestTrigger = CharacterCollider;
        }

        public override void ProcessActivate()
        {
            _compliteQuestTrigger.enabled = true;
        }

        public override void ProcessComplete()
        {
            _compliteQuestTrigger.enabled = false;
        }
    }
}
