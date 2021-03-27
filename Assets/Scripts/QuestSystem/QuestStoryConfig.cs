using UnityEngine;

namespace Shipov_QuestSystem
{
    [CreateAssetMenu(menuName = "QuestStoryConfig", fileName = "QuestStoryConfig", order = 0)]
    public class QuestStoryConfig : ScriptableObject
    {
        public QuestConfig[] quests;
        public QuestStoryType questStoryType;
    }
}

