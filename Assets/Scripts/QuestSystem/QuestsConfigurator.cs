using UnityEngine;

namespace Shipov_QuestSystem
{
    public class QuestsConfigurator : MonoBehaviour
    {
        [SerializeField] private BaseQuestObjectView _singleQuestView;
        [SerializeField] private QuestUI _questUI;
        private Quest _singleQuest;

        private void Start()
        {
            _singleQuest = new Quest(_singleQuestView, new SwitchQuestModel(), _questUI);
            _singleQuest.Reset();
        }

        private void OnDestroy()
        {
            _singleQuest.Dispose();
        }
    }
}
